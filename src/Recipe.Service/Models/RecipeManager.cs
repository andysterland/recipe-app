using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml;

namespace Recipe.Service.Models
{
    public class RecipeManager
    {
        public static RecipeManager Singleton;

        static RecipeManager()
        {
            Singleton = new RecipeManager();
        }

        private string _recipesPath = "~//App_Data/Recipes";
        private Dictionary<long?, Recipe> _recipes = new Dictionary<long?, Recipe>();
        private Random _random = new Random(new DateTime().Millisecond);
        
        public RecipeManager()
        {
            LoadRecipes();
        }

        [Instrument.API.Instrument]
        public void LoadRecipes()
        {
            DateTime startTime = new DateTime();
            string resolvedPath = System.Web.HttpContext.Current.Server.MapPath(_recipesPath);
            string[] files = Directory.GetFiles(resolvedPath);

            foreach (string fileName in files)
            {
                string json = File.ReadAllText(fileName);
                Recipe recipe = LoadRecipeFromJson(json);
                //DEMO: Step back
                _recipes.Add(recipe.Id, recipe);
            }
            TimeSpan duration = DateTime.Now - startTime;
            Global.AI.TrackMetric("Recipe-LoadFromJsonTime", duration.TotalMilliseconds);
        }

        public Recipe GetRecipeById(long id)
        {
            if (!_recipes.ContainsKey(id))
            {
                return null;
            }
            return _recipes[id];
        }

        public List<Recipe> GetRecipes(int start, int limit, string sortBy, string orderBy)
        {
            IEnumerable<Recipe> recipes = (from recipe in _recipes.Values
                                           orderby recipe.SpoonacularScore descending
                                           select recipe).Skip(start).Take(limit);

            return recipes.ToList();
        }

        public List<Recipe> GetRecipesByName(string name) {
            Recipe[] recipesArray = _recipes.Values.ToArray();
            List<Recipe> recipes = null; //new List<Recipe>();

            for (int i = 0; i < recipesArray.Length; i++) {

                // Perform case insensitive search
                if (recipesArray[i].Title.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0) {
                    recipes.Add(recipesArray[i]);
                }
            }
            return recipes;
        }

        public List<Recipe> GetRecipesByHighestRated()
        {
            List<Recipe> recipes = _recipes.Values.ToList();

            foreach (Recipe recipe in _recipes.Values)
            {
                for (int i = 0; i < recipes.Count; i++)
                {
                    for (int j = recipes.Count - 1; j > i; j--)
                    {
                        uint scoreA = Convert.ToUInt32(recipes[j].SpoonacularScore);
                        uint scoreB = Convert.ToUInt32(recipes[j - 1].SpoonacularScore);
                        if (scoreA > scoreB)
                        {
                            var temp = recipes[j];
                            recipes[j] = recipes[j - 1];
                            recipes[j - 1] = temp;
                        }
                    }
                }
            }

            return recipes;
        }

        public bool SpeedTest()
        {
            List<Recipe> linqRecipes = GetRecipesLinqSpeedTest();

            List<Recipe> bubbleSortRecipes = GetRecipesBubbleSortSpeedTest();

            // Pointless comparison.
            bool hasSameTopResult = linqRecipes[0].Id == bubbleSortRecipes[0].Id;

            return hasSameTopResult;
        }

        public Recipe GetRandom()
        {
            int index = _random.Next(0, _recipes.Count - 1);

            return _recipes[index];
        }

        private Recipe LoadRecipeFromJson(string json)
        {
            return JsonConvert.DeserializeObject<Recipe>(json, Converter.Settings);
        }

        internal class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

        private List<Recipe> GetRecipesLinqSpeedTest()
        {
            List<Recipe> linqRecipes = null;
            for (int i = 0; i < 100; i++)
            {
                List<Recipe> lingqLocalCopy = new List<Recipe>(_recipes.Values);
                linqRecipes = GetRecipesLinqSpeedTestInner(lingqLocalCopy);
            }

            return linqRecipes;
        }

        private List<Recipe> GetRecipesLinqSpeedTestInner(List<Recipe> recipes)
        {
            recipes = ( from recipe in recipes
                        orderby recipe.SpoonacularScore descending
                        select recipe).Take(10).ToList();

            return recipes;
        }
        private List<Recipe> GetRecipesBubbleSortSpeedTest()
        {
            List<Recipe> bubbleSortRecipes=null;
            for (int i = 0; i < 100; i++)
            {
                List<Recipe> bubbleSortLocalCopy = new List<Recipe>(_recipes.Values);
                bubbleSortRecipes = GetRecipesBubbleSortSpeedTestInner(bubbleSortLocalCopy);
            }

            return bubbleSortRecipes;
        }

        private List<Recipe> GetRecipesBubbleSortSpeedTestInner(List<Recipe> recipes)
        {
            for (int i = 0; i < recipes.Count; i++)
            {
                for (int j = recipes.Count - 1; j > i; j--)
                {
                    if (recipes[j].SpoonacularScore < recipes[j - 1].SpoonacularScore)
                    {
                        var temp = recipes[j];
                        recipes[j] = recipes[j - 1];
                        recipes[j - 1] = temp;
                    }
                }
            }

            return recipes;
        }
    }
}
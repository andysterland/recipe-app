using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml;

namespace Recipe.Monolith.Models
{
    public class RecipeManager
    {

        private static Dictionary<long?, Recipe> recipes = null;
        private static IEnumerator<long?> keysEnumerator;
        public Recipe NextRecipe
        {
            get
            {
                if (!keysEnumerator.MoveNext())
                {
                    keysEnumerator.Reset();
                }

                return recipes[keysEnumerator.Current];
            }
            set { }
        }

        static RecipeManager()
        {
            recipes = new Dictionary<long?, Recipe>();

            string resolvedPath = Path.Combine(Global.Singleton.DataPath, "Recipes");

            string[] filenames = Directory.GetFiles(resolvedPath);
            foreach(string filename in filenames)
            {
                string json = File.ReadAllText(filename);
                Recipe recipe = LoadRecipeFromJson(json);
                recipes.Add(recipe.Id, recipe);
            }

            keysEnumerator = recipes.Keys.GetEnumerator();
        }

        public static List<Recipe> GetAll()
        {
            return recipes.Values.ToList();
        }

        public static List<Recipe> GetAll(int Count)
        {
            return recipes.Values.Take<Recipe>(Count).ToList();
        }

        public static Recipe GetRecipeById(long id)
        {
            if(!recipes.ContainsKey(id))
            {
                return null;
            }
            return recipes[id];
        }

        // GetAllByName
        public static List<Recipe> GetAllByName(string Name)
        {
            return Search(Name, 0, 100);
        }

        public static List<Recipe> Search(string term, int start, int limit)
        {
            // Note: This is obvioussly insane and done for the sake of a demo
            List<Recipe> recipesArray = new List<Recipe>();

            foreach(Recipe r in recipes.Values.ToList())
            {
                if(!string.IsNullOrWhiteSpace(term))
                {
                    if(r.Title.Contains(term))
                    {
                        recipesArray.Add(r);
                    }
                }
                else
                {
                    recipesArray.Add(r);
                }
            }

            for (int i = 0; i < recipesArray.Count; i++)
            {
                for (int j = 0; j < recipesArray.Count - i - 1; j++)
                {
                    if (recipesArray[j].SpoonacularScore > recipesArray[j + 1].SpoonacularScore)
                    {
                        Recipe tempRecipe = recipesArray[j];
                        recipesArray[j] = recipesArray[j + 1];
                        recipesArray[j + 1] = tempRecipe;
                    }
                }
            }
            
            IEnumerable<Recipe> returnRecipe = recipesArray.ToList();
            returnRecipe = returnRecipe.Skip(start).Take(limit);

            return (List<Recipe>)returnRecipe.ToList();
        }
        
        private static Recipe LoadRecipeFromJson(string json)
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

    }
}
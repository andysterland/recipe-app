using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recipe.Monolith.Models
{
    public class RecipesViewModel
    {
        public static async Task<RecipesViewModel> GetRecipeViewModelByName(string searchTerm)
        {
            RecipesViewModel search = null;

            List<Recipe> recipes = await GetRecipeByName(searchTerm);

            if(recipes != null && recipes.Count == 1 && recipes[0] != null && recipes[0].Id == null)
            {
                recipes = null;
            }

            search = new RecipesViewModel(searchTerm, recipes);

            return search;
        }
        public static async Task<RecipesViewModel> GetRecipeViewModelByHighestRated()
        {
            RecipesViewModel search = null;

            List<Recipe> recipes = await GetAllRecipesByRating();
            search = new RecipesViewModel("", recipes);

            return search;
        }

        public static async Task<RecipesViewModel> GetRecipeViewModel()
        {
            RecipesViewModel search = null;

            List<Recipe> recipes = await GetAllRecipes();
            //DEMO: 06 - DebuggerDisplay View
            search = new RecipesViewModel("", recipes);
            //DEMO: 05 - $ReturnValue, $ReturnValue1 etc...
            var temp = "   Hello world!   ".ToLower().ToUpper().Trim();

            return search;
        }

        private static async Task<List<Models.Recipe>> GetAllRecipes()
        {
            // DEMO: 01 - Run To 
            List<Models.Recipe> recipes = new List<Recipe>();
            try
            {
                recipes = RecipeManager.GetAll();
            }
            catch (Exception ex)
            {
                Global.Singleton.AI.TrackException(ex);
                return null;
            }
            // TODO: DEMO: 02 - Step Into Specific

            return recipes;
        }

        private static async Task<List<Models.Recipe>> GetRecipeByName(string name)
        {
            List<Models.Recipe> recipes = new List<Recipe>();

            try
            {
                recipes = RecipeManager.GetAllByName(name);
            }
            catch (Exception ex)
            {
                Global.Singleton.AI.TrackException(ex);
                return null;
            }
            // DEMO: 03 - Tracepoints ($FUNCTION {response.Data.Count} matches), show parameter values in the Call Stack 
            return recipes;
        }
        
        private static async Task<List<Models.Recipe>> GetAllRecipesByRating()
        {
            return RecipeManager.GetAll();
        }

        private static Recipe GetRandom(List<Recipe> Recipes)
        {
            // DEMO: 04 - NSE
            Random random = new Random(new DateTime().Millisecond);
            int index = random.Next(0, Recipes.Count - 1);

            return Recipes[index];
        }

        private static string GetFancyName(string Name)
        {
            return Name.ToUpper();
        }

        public string SearchTerm
        {
            get;
            private set;
        }
        public List<Recipe> Recipes
        {
            get;
            private set;
        }

        public RecipesViewModel(string searchTerm, List<Recipe> recipes)
        {
            this.Recipes = recipes;
            this.SearchTerm = searchTerm;
        }
    }
}
// DEMO: 03 - Hack for break on change
// Need to open the other app!
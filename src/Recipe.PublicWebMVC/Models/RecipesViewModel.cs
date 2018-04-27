using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PublicWebMVC.Models
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

        public static async Task<RecipesViewModel> GetRecipeViewModel()
        {
            RecipesViewModel search = null;

            List<Recipe> recipes = await GetAllRecipes();
            //DEMO: DebuggerDisplay
            search = new RecipesViewModel("", recipes);
            //DEMO: $ReturnValue, $ReturnValue1 etc...
            var temp = "   Hello world!   ".ToLower().ToUpper().Trim();

            return search;
        }

        private static async Task<List<Models.Recipe>> GetRecipeByName(string name)
        {
            // Note: This is all crazytown code to demonstrate snapshots on exceptions
            Uri restApiUri; 

            if(Global.Singleton.IsDevelopment)
            {
                restApiUri = new Uri("http://localhost:64407");
            }
            else
            {
                restApiUri = Global.Singleton.RestApiUri;
            }

            RestClient apiClient = new RestClient(restApiUri);

            RestRequest request = new RestRequest();
            request.Resource = "api/recipes/search/{name}";
            request.AddUrlSegment("name", name);

            IRestResponse<List<Models.Recipe>> response = null;

            try
            {
                var cancellationTokenSource = new CancellationTokenSource();
                response = await apiClient.ExecuteTaskAsync<List<Models.Recipe>>(request, cancellationTokenSource.Token);

                if (response.ErrorException != null)
                {
                    throw response.ErrorException;
                }
            }
            catch (Exception ex)
            {
                // Todo: Log errors...
                return null;
            }
            
            return response.Data;
        }
        
        private static async Task<List<Models.Recipe>> GetAllRecipes()
        {
            DateTime startTime = new DateTime();
            // DEMO: Run To           
            RestRequest request = new RestRequest();
            request.Resource = "api/recipes/";

            IRestResponse<List<Models.Recipe>> response = null;

            try
            {
                var cancellationTokenSource = new CancellationTokenSource();
                response = await Global.Singleton.ApiClient.ExecuteTaskAsync<List<Models.Recipe>>(request, cancellationTokenSource.Token);

                if (response.ErrorException != null)
                {
                    throw response.ErrorException;
                }
            }
            catch (Exception ex)
            {
                // Todo: Log errors...
                return null;
            }
            // DEMO: Step Into Specific
            string title = GetFancyName(GetRandom(response.Data).Title.ToUpper());


            TimeSpan duration = DateTime.Now - startTime;
            Global.Singleton.AI.TrackMetric("RecipeWWW-GetAllRecipes-Duration", duration.TotalMilliseconds);

            return response.Data;
        }









        private static Recipe GetRandom(List<Recipe> Recipes)
        {
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

using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PublicWebMVC.Models
{
    public class RecipeViewModel
    {
        public static async Task<RecipeViewModel> GetRecipeViewModelById(long id)
        {
            Recipe recipe = await GetRecipeById(id);
            RecipeViewModel viewModel = new RecipeViewModel(recipe);

            return viewModel;
        }


        private static async Task<Recipe> GetRecipeById(long id)
        {
            // Note: This is all crazytown code to demonstrate snapshots on exceptions
            RestRequest request = new RestRequest();
            request.Resource = "api/recipes/{id}";
            request.AddUrlSegment("id", id);

            IRestResponse<Recipe> response = null;

            try
            {
                var cancellationTokenSource = new CancellationTokenSource();
                response = await Global.Singleton.ApiClient.ExecuteTaskAsync<Recipe>(request, cancellationTokenSource.Token);

                if (response.ErrorException != null)
                {
                    throw response.ErrorException;
                }
            }
            catch (Exception ex)
            {
                // DEMO: Snapshots on exceptions
                Global.Singleton.AI.TrackException(ex);

                return null;
            }

            return response.Data;
        }
        public Recipe Recipe;

        public RecipeViewModel(Recipe Recipe)
        {
            this.Recipe = Recipe;
        }
    }
}

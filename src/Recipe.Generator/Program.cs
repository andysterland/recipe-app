using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Generator
{
    class Program
    {
        private static string apiUri = "https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/random?limitLicense=true&number=10";
        static void Main(string[] args)
        {
            string json = GetJsonStream();
            var recipeResponse = RecipeResponse.FromJson(json);
            foreach (Recipe recipe in recipeResponse.Recipes)
            {
                string filename = $"{recipe.Id}.json";
                string recipeJson = JsonConvert.SerializeObject(recipe, Converter.Settings);
                File.WriteAllText(filename, recipeJson);
            }
        }

        static string GetJsonStream()
        {
            WebClient client = new WebClient();

            string url = apiUri;
            client.Headers.Add("X-Mashape-Key", "7e70aJOqermshUsxQ42UAv5BzzKYp1juV2Qjsn0yFw2AnquYw3");
            client.Headers.Add("Accept", "application/json");

            string response = client.DownloadString(url);

            Debug.WriteLine("Content: " + response);

            return response;
        }
    }
}
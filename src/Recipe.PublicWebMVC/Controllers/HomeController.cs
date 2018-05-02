using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PublicWebMVC.Models;
using RestSharp;

namespace PublicWebMVC.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            RecipesViewModel recipeViewModel = await RecipesViewModel.GetRecipeViewModel();

            return View(recipeViewModel);
        }

        public async Task<IActionResult> Search(string searchString)
        {
            // DEMO_AI: TrackEvent
            Global.Singleton.AI.TrackEvent("Recipe/Search", new Dictionary<string, string> { { "SearchTerm", searchString } } );
            RecipesViewModel recipeViewModel = null;

            if (String.IsNullOrEmpty(searchString))
            {
                return RedirectToAction("Index");
            }
            
            recipeViewModel = await RecipesViewModel.GetRecipeViewModelByName(searchString);
            
            return View("Index", recipeViewModel);
        }
        public async Task<IActionResult> Top()
        {
            RecipesViewModel recipeViewModel = await RecipesViewModel.GetRecipeViewModelByHighestRated();

            return View("Index", recipeViewModel);
        }

        public async Task<IActionResult> Recipe(string id)
        {
            long idAsLong = 0;
            if (!long.TryParse(id, out idAsLong))
            {
                throw new ArgumentException("Invalid id");
            }

            RecipeViewModel recipe = await RecipeViewModel.GetRecipeViewModelById(idAsLong);

            if (recipe == null)
            {
                throw new Exception($"Recipe not found for id {id}");
            }

            return View(recipe);
        }

        public IActionResult Error(HttpStatusCode statusCode)
        {
            ErrorViewModel errorViewModel;
            switch (statusCode)
            {
                case HttpStatusCode.NotFound:
                    errorViewModel = new ErrorViewModel(Activity.Current?.Id ?? HttpContext.TraceIdentifier, "Page Not Found", "Sorry, but we couldn't find the page you were looking for.", statusCode);
                    break;

                default:
                    errorViewModel = new ErrorViewModel(Activity.Current?.Id ?? HttpContext.TraceIdentifier, "Error", "Whoops, an unknown error occured.", HttpStatusCode.InternalServerError);
                    break;
            }

            return View(errorViewModel); 
        }
    }
}

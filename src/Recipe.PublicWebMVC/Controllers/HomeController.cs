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
            RecipesViewModel recipeViewModel = null;

            if (String.IsNullOrEmpty(searchString))
            {
                return RedirectToAction("Index");
            }

            recipeViewModel = await RecipesViewModel.GetRecipeViewModelByName(searchString);

            return View("Index", recipeViewModel);
        }

        public async Task<IActionResult> Recipe(string id)
        {
            long idAsLong = 0;
            if (!long.TryParse(id, out idAsLong))
            {
                throw new Exception("Invalid id");
            }

            RecipeViewModel recipe = await RecipeViewModel.GetRecipeViewModelById(idAsLong);

            if (recipe == null)
            {
                throw new Exception($"Recipe not found for id {id}");
            }

            return View(recipe);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

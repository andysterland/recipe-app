using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recipe.Monolith.Models;

namespace Recipe.Monolith.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Recipe.Monolith.Models.Recipe> recipes = RecipeManager.GetAll(12);

            ViewData["Recipes"] = recipes;
            ViewData["Title"] = "Fabrikam Recipes";

            return View();
        }

        public IActionResult Recipe(string id)
        {
            long idAsLong = 0;
            if (!long.TryParse(id, out idAsLong))
            {
                throw new Exception("Invalid id");
            }

            Recipe.Monolith.Models.Recipe recipe = RecipeManager.GetRecipeById(idAsLong);
            if (recipe == null)
            {
                throw new Exception($"Recipe not found for id {id}");
            }

            // increase hit count for selected recipe
            if (recipe.Hits == null)
            {
                recipe.Hits = 1;
            }
            else
            {
                recipe.Hits++;
            }
            RecipeManager.UpdateRecipe(idAsLong, recipe);

            return View(recipe);
        }

        public IActionResult SearchResults(string searchString)
        {
            List<Recipe.Monolith.Models.Recipe> recipes = new List<Recipe.Monolith.Models.Recipe>();

            if (!String.IsNullOrEmpty(searchString))
            {
                recipes = RecipeManager.GetAllByName(searchString);
            }
            ViewData["Recipes"] = recipes;
            ViewData["Title"] = "SearchResults";

            return View(recipes);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

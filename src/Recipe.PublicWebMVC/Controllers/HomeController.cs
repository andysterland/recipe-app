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
            List<Recipe.Monolith.Models.Recipe> recipes = RecipeManager.GetAll();

            ViewData["Recipes"] = recipes;
            ViewData["Title"] = "Fabrikam Recipes";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

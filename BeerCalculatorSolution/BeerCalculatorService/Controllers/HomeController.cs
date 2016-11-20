using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.DTOs;

namespace BeerCalculatorService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetItem(int id)
        {
            var recipe = new RecipeDTO();
            recipe.RecipeID = 1;
            recipe.RecipeName = "Hoppiness is an IPA";
            recipe.ExpectedABV = 7.1;
            return Json(recipe);
        }
    }
}

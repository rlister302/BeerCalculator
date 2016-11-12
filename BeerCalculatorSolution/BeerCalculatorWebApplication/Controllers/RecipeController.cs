using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Models;

namespace BeerCalculatorWebApplication.Controllers
{
    public class RecipeController : Controller
    {
        public ActionResult GetRecipes()
        {
            var recipeList = new List<RecipeDTO>();
            var recipe1 = new RecipeDTO { RecipeName = "Lager" };
            var recipe2 = new RecipeDTO { RecipeName = "IPA" };
            var recipe3 = new RecipeDTO { RecipeName = "Stout" };
            recipeList.Add(recipe1);
            recipeList.Add(recipe2);
            recipeList.Add(recipe3);
            return Json(recipeList);
        }

        public ActionResult GetRecipe(int id)
        {
            return null;
        }

        public ActionResult CreateRecipe(RecipeDTO create)
        {
            return null;
        }

        public ActionResult UpdateRecipe(RecipeDTO update)
        {
            return null;
        }

        public ActionResult DeleteRecipe(int id)
        {
            return null;
        }
    }
}

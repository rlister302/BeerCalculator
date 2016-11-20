using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.DTOs;

namespace BeerCalculatorService.Controllers
{
    public class RecipeController : Controller
    {
        //
        // GET: /Recipe/

        public ActionResult GetRecipes()
        {
            return View();
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

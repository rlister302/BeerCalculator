using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Models.Models;
using Models.Communication;

namespace BeerCalculatorWebApplication.Controllers
{
    public class RecipeController : Controller
    {
        public async Task<ActionResult> GetRecipes()
        {
            var response = await new RequestManager().Test();
            return Json(response);
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

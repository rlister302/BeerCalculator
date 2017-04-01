using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Common.DTOs;
using Common.Communication;


namespace BeerCalculatorWebApplication.Controllers
{
    public class RecipeController : Controller
    {
        private RecipeRequestManager _requestManager;

        public RecipeController()
        {
            _requestManager = new RecipeRequestManager();
        }
        [HttpGet]
        public ActionResult CreateRecipe()
        {
            return PartialView();
        }
        public async Task<ActionResult> GetRecipes()
        {
            var model = await _requestManager.RetreiveAll(new RecipeDTO());
            return Json(model);
        }

        public ActionResult GetRecipe(int id)
        {
            return null;
        }
        [HttpPost]
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

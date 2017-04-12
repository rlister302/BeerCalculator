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
        public async Task<ActionResult> CreateRecipe()
        {
            var ingredients = await new IngredientRequestManager().Retreive(new IngredientDTO());
            return PartialView(ingredients);
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
        public async Task<ActionResult> CreateRecipe(RecipeDTO create)
        {
            var x = create;
            var result = await _requestManager.Create(create);
            return Json(result);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using BeerCalculator.Common.Communication;
using BeerCalculator.Common.DTOs;

namespace BeerCalculatorWebApplication.Controllers
{
    public class RecipeController : Controller
    {
        private RecipeRequestManager _requestManager = new RecipeRequestManager();

        [HttpGet]
        public async Task<ActionResult> CreateRecipe()
        {
            var ingredients = await new IngredientRequestManager().Retreive(new IngredientDTO());
            return PartialView(ingredients);
        }
        [HttpGet]
        public async Task<ActionResult> GetRecipes()
        {
            var model = await _requestManager.RetreiveAll(new RecipeDTO());
            return Json(model);
        }

        [HttpGet]
        public async Task<ActionResult> RecipeManagement()
        {
            var model = await _requestManager.RetreiveAll(new RecipeDTO());
            return PartialView(model);
        }

        [HttpGet]
        public async Task<ActionResult> GetRecipe(RecipeDTO get)
        {
            var model = await _requestManager.Retreive(get);
            return Json(model);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRecipe(RecipeDTO create)
        {
            var result = await _requestManager.Create(create);
            return Json(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRecipe(RecipeDTO update)
        {
            var model = await _requestManager.Update(update);
            return Json(model);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteRecipe(RecipeDTO delete)
        {
            var model = await _requestManager.Delete(delete);
            return Json(model);
        }
    }
}

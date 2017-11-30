using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using BeerCalculator.Common.Communication;
using BeerCalculator.Common.DTOs;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;
using BeerCalculator.WebApplication.BootStrapper;

namespace BeerCalculatorWebApplication.Controllers
{
    public class RecipeController : Controller
    {
        private IRequestManager requestManager = new RequestManager();

        public RecipeController()
        {
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);
            new WebAppBootStrapper(container, locator);
            requestManager = container.Resolve<IRequestManager>();
        }

        [HttpGet]
        public async Task<ActionResult> CreateRecipe()
        {
            var ingredients = await requestManager.GetAll(new IngredientDTO(), typeof(MessageContainer<IngredientDTO>));
            return PartialView(ingredients);
        }
        [HttpGet]
        public async Task<ActionResult> GetRecipes()
        {
            var model = await requestManager.GetAll(new RecipeDTO(), typeof(MessageContainer<IEnumerable<RecipeDTO>>));
            return Json(model);
        }

        [HttpGet]
        public async Task<ActionResult> RecipeManagement()
        {
            var model = await requestManager.GetAll(new RecipeDTO(), typeof(MessageContainer<IEnumerable<RecipeDTO>>));
            return PartialView(model);
        }

        [HttpGet]
        public async Task<ActionResult> GetRecipe(int get)
        {
            var model = await requestManager.Get(new RecipeDTO() { RecipeID = get }, typeof(MessageContainer<RecipeDTO>));
            return PartialView("RecipeDetails.cshtml", model);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRecipe(RecipeDTO create)
        {
            var result = await new RequestManager().Create(create, typeof(bool));
            return Json(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRecipe(RecipeDTO update)
        {
            var model = await requestManager.Update(update, typeof(MessageContainer<bool>));
            return Json(model);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteRecipe(RecipeDTO delete)
        {
            var model = await requestManager.Delete(delete, typeof(MessageContainer<bool>));
            return Json(model);
        }
    }
}

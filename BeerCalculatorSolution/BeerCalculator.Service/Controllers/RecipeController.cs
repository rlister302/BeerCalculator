using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.DataAccess;
using Newtonsoft.Json;
using BeerCalculator.Common.DTOs;
using BeerCalculator.DataAccessLayer.DataAccess;
using BeerCalculator.Service.Converter;
using BeerCalculator.Calculators.Interface;
using DataAccessLayer.DataAccess.Interface;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;
using BeerCalculator.Service.Bootstrapper;

namespace BeerCalculatorService.Controllers
{
    public class RecipeController : Controller
    {
        private IDataAccess<RecipeDTO> recipeDataAccess;
        private IDataAccess<IngredientDTO> ingredientDataAccess;

        public RecipeController()
        {
            ResolveDependencies();
        }

        private void ResolveDependencies()
        {
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);
            new ServiceBootstapper(container, locator);
            recipeDataAccess = container.Resolve<IDataAccess<RecipeDTO>>();
            ingredientDataAccess = container.Resolve<IDataAccess<IngredientDTO>>();
        }

        [HttpGet]
        public ActionResult GetAllRecipes()
        {
            var data = recipeDataAccess.Get();
            MessageContainer<IEnumerable<RecipeDTO>> container = new MessageContainer<IEnumerable<RecipeDTO>>() { Data = data };
            return Json(container, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetRecipeDetails(RecipeDTO details)
        {
            RecipeDetailsDTO data = GetRecipeDetailDTO(details);
            MessageContainer<RecipeDetailsDTO> container = new MessageContainer<RecipeDetailsDTO>() { Data = data };
            return Json(container);
        }

        private RecipeDetailsDTO GetRecipeDetailDTO(RecipeDTO details)
        {
            RecipeDetailsDTO data = new RecipeDetailsDTO();
            data.Ingredients = ingredientDataAccess.Get(0);
            data.Recipe = recipeDataAccess.Get(details.RecipeID);
            MessageContainer<RecipeDetailsDTO> container = new MessageContainer<RecipeDetailsDTO>() { Data = data };
            return data;
        }

        [HttpPost]
        public ActionResult CreateRecipe(RecipeDTO create)
        {
            var data = recipeDataAccess.Create(create);
            MessageContainer<bool> container = new MessageContainer<bool>() { Data = data };
            return Json(container);
        }

        [HttpPut]
        public ActionResult UpdateRecipe(RecipeDTO update)
        {
            var data = recipeDataAccess.Update(update);
            MessageContainer<bool> container = new MessageContainer<bool>() { Data = data };
            return Json(container);
        }

        [HttpDelete]
        public ActionResult DeleteRecipe(RecipeDTO delete)
        {
            var data = recipeDataAccess.Create(delete);
            MessageContainer<bool> container = new MessageContainer<bool>() { Data = data };
            return Json(container);
        }
    }
}

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

namespace BeerCalculatorService.Controllers
{
    public class RecipeController : Controller
    {
        private IDataAccess<RecipeDTO> dataAccess;
        private IConverter converter;
        private IBeerMetricsCalculator calculator;

        public RecipeController()
        {
            dataAccess = new RecipeDataAccess();
        }

        [HttpGet]
        public ActionResult GetAllRecipes()
        {
            var data = dataAccess.Get();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetRecipeDetails(RecipeDTO details)
        {
            var data = dataAccess.Get(details);
            return Json(data);
        }

        [HttpPost]
        public ActionResult CreateRecipe(RecipeDTO create)
        {
            var data = dataAccess.Create(create);
            //IRecipeInput input = converter.Convert()
            return Json(data);
        }

        [HttpPut]
        public ActionResult UpdateRecipe(RecipeDTO update)
        {
            var data = dataAccess.Update(update);
            return Json(data);
        }

        [HttpDelete]
        public ActionResult DeleteRecipe(RecipeDTO delete)
        {
            var data = dataAccess.Create(delete);
            return Json(data);
        }
    }
}

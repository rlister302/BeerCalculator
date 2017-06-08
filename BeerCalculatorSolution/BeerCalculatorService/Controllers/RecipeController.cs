using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.DTOs;
using DataAccessLayer.DataAccess;
using Newtonsoft.Json;
namespace BeerCalculatorService.Controllers
{
    public class RecipeController : Controller
    {
        private RecipeDataAccess _dataAccess;

        public RecipeController()
        {
            _dataAccess = new RecipeDataAccess();
        }

        [HttpGet]
        public ActionResult GetAllRecipes()
        {
            var data = _dataAccess.Get();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetRecipeDetails(RecipeDTO details)
        {
            var data = _dataAccess.Get(details);
            return Json(data);
        }

        [HttpPost]
        public ActionResult CreateRecipe(RecipeDTO create)
        {
            var data = _dataAccess.Create(create);
            return Json(data);
        }

        [HttpPut]
        public ActionResult UpdateRecipe(RecipeDTO update)
        {
            var data = _dataAccess.Update(update);
            return Json(data);
        }

        [HttpDelete]
        public ActionResult DeleteRecipe(RecipeDTO delete)
        {
            var data = _dataAccess.Create(delete);
            return Json(data);
        }
    }
}

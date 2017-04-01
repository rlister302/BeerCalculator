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
        public ActionResult GetAllRecipes()
        {
            var data = _dataAccess.Get();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRecipeDetails(RecipeDTO details)
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

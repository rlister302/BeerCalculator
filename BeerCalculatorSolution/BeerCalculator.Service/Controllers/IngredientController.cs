using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.DataAccess;
using BeerCalculator.DataAccessLayer.DataAccess;
using BeerCalculator.Common.DTOs;
using DataAccessLayer.DataAccess.Interface;

namespace BeerCalculatorService.Controllers
{
    public class IngredientController : Controller
    {
        private IDataAccess<IngredientDTO> dataAccess = new IngredientDataAccess();
        [HttpGet]
        public ActionResult GetAllIngredients()
        {
            var returnObject = dataAccess.Get(new IngredientDTO());
            var container = new MessageContainer<IngredientDTO>() { Data = returnObject };
            return Json(container, JsonRequestBehavior.AllowGet);
        }
    }
}

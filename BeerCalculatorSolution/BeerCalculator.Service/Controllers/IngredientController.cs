﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.DataAccess;
using BeerCalculator.DataAccessLayer.DataAccess;
using BeerCalculator.Common.DTOs;

namespace BeerCalculatorService.Controllers
{
    public class IngredientController : Controller
    {
        [HttpGet]
        public ActionResult GetAllIngredients()
        {
            var returnObject = new IngredientDataAccess().Get(new IngredientDTO());
            return Json(returnObject, JsonRequestBehavior.AllowGet);
        }
    }
}

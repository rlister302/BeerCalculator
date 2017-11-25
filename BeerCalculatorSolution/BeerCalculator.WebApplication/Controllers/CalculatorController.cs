using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using BeerCalculator.Common.Interface;
using BeerCalculator.Common.Communication;
using Newtonsoft.Json;
using BeerCalculator.Common.Implementation;
using BeerCalculator.Common.DTOs;

namespace BeerCalculator.WebApplication.Controllers
{
    public class CalculatorController : Controller
    {
        CalculatorRequestManager requestManager = new CalculatorRequestManager();
        
        [HttpPost]
        public async Task<ActionResult> Calculate(RecipeInputDTO recipeInput)
        {
       
            var result = await requestManager.GetMetrics(recipeInput);
            return Json(result);
        }
    }
}
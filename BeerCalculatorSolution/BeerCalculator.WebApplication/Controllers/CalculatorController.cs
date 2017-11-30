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
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using BeerCalculator.WebApplication.BootStrapper;

namespace BeerCalculator.WebApplication.Controllers
{
    public class CalculatorController : Controller
    {
        IRequestManager requestManager;

        public CalculatorController()
        {
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);
            new WebAppBootStrapper(container, locator);
            requestManager = container.Resolve<IRequestManager>();
        }
        
        [HttpPost]
        public async Task<ActionResult> Calculate(RecipeInputDTO recipeInput)
        {
       
            var result = await requestManager.Create(recipeInput, typeof(MessageContainer<RecipeMetricsDTO>));
            return Json(result);
        }
    }
}
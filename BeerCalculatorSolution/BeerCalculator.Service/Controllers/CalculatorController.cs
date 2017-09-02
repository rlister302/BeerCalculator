using BeerCalculator.Common.Interface;
using BeerCalculators.Calculators;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BeerCalculatorService.Controllers
{
    public class CalculatorController : Controller
    {
        IBeerMetricsCalculator calculator;

        public CalculatorController()
        {
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);
            new CalculatorBootStrapper(container, locator);
            calculator = container.Resolve<IBeerMetricsCalculator>();
        }

        [HttpPost]
        public ActionResult GetMetrics(IRecipeInput recipeInput)
        {
            IRecipeMetrics metrics = calculator.Calculate(recipeInput);
            return Json(metrics);
        }
    }
}

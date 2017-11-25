using BeerCalculator.Calculators.Implementation;
using BeerCalculator.Calculators.Interface;
using BeerCalculator.Common.DTOs;
using BeerCalculator.Common.Implementation;
using BeerCalculator.Common.Interface;
using BeerCalculators.Calculators;
using BeerCalculators.Calculators.Implementation;
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
        IRecipeMetaDataResolver resolver;

        public CalculatorController()
        {
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);
            new CalculatorBootStrapper(container, locator);
            calculator = container.Resolve<IBeerMetricsCalculator>();
            resolver = container.Resolve<IRecipeMetaDataResolver>();
        }

        [HttpPost]
        public ActionResult GetMetrics(RecipeInputDTO recipeInput)
        {
            resolver.ResolveGrainMetaData(recipeInput.Grains);
            IRecipeInput converted = Convert(recipeInput);
            IRecipeMetrics metrics = calculator.Calculate(converted);
            return Json(metrics);
        }

        private IRecipeInput Convert(RecipeInputDTO input)
        {
            IRecipeInput converted = new RecipeInput();
            return converted;
        }
    }
}

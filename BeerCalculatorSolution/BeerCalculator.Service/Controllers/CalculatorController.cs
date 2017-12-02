using BeerCalculator.Calculators.Interface;
using BeerCalculator.Common.DTOs;
using BeerCalculator.Common.Implementation;
using BeerCalculator.Common.Interface;
using BeerCalculator.Service.Bootstrapper;
using BeerCalculator.Service.Converter;
using BeerCalculators.Calculators.Implementation;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System.Web.Mvc;

namespace BeerCalculatorService.Controllers
{
    public class CalculatorController : Controller
    {
        IBeerMetricsCalculator calculator;
        IRecipeMetaDataResolver resolver;
        IConverter converter;

        public CalculatorController()
        {
            ResolveDependencies();
        }

        private void ResolveDependencies()
        {
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);
            new ServiceBootstapper(container, locator);
            calculator = container.Resolve<IBeerMetricsCalculator>();
            resolver = container.Resolve<IRecipeMetaDataResolver>();
            converter = container.Resolve<IConverter>();
        }

        [HttpPost]
        public ActionResult GetMetrics(RecipeInputDTO recipeInput)
        {
            resolver.ResolveGrainMetaData(recipeInput.Grains);
            IRecipeInput converted = converter.Convert(recipeInput);
            IRecipeMetrics metrics = calculator.Calculate(converted);
            return Json(new MessageContainer<RecipeMetricsDTO>() { Data = metrics.ToDTO() });
        }
    }
}

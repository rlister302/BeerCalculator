using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeerCalculator.DataAccessLayer.DataAccess;
using BeerCalculator.Common.DTOs;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;
using BeerCalculator.Service.Bootstrapper;
using BeerCalculator.DataAccessLayer.DataAccess.Interface;
using BeerCalculator.DataAccessLayer;

namespace BeerCalculatorService.Controllers
{
    public class IngredientController : Controller
    {
        private IDataAccess<IngredientDTO, Recipe> dataAccess;

        public IngredientController()
        {
            ResolveDependencies();
        }

        public void ResolveDependencies()
        {
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);
            new ServiceBootstapper(container, locator);
            dataAccess = container.Resolve<IDataAccess<IngredientDTO, Recipe>>();
        }

        [HttpGet]
        public ActionResult GetAllIngredients()
        {
            var returnObject = dataAccess.Get(0);
            var container = new MessageContainer<IngredientDTO>() { Data = returnObject };
            return Json(container, JsonRequestBehavior.AllowGet);
        }
    }
}

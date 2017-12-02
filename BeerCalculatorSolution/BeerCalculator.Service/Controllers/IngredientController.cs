using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.DataAccess;
using BeerCalculator.DataAccessLayer.DataAccess;
using BeerCalculator.Common.DTOs;
using DataAccessLayer.DataAccess.Interface;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;
using BeerCalculator.Service.Bootstrapper;

namespace BeerCalculatorService.Controllers
{
    public class IngredientController : Controller
    {
        private IDataAccess<IngredientDTO> dataAccess;

        public IngredientController()
        {
            ResolveDependencies();
        }

        public void ResolveDependencies()
        {
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);
            new ServiceBootstapper(container, locator);
            dataAccess = container.Resolve<IDataAccess<IngredientDTO>>();
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

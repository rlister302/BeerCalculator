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
    public class GrainTypeController : Controller
    {
        private IDataAccess<GrainTypeDTO> dataAccess;
        public GrainTypeController()
        {
            ResolveDependencies();
        }

        public void ResolveDependencies()
        {
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);
            new ServiceBootstapper(container, locator);
            dataAccess = container.Resolve<IDataAccess<GrainTypeDTO>>();
  
        }

        [HttpGet]
        public ActionResult GetAllGrainTypes()
        {
            var result = dataAccess.Get();
            MessageContainer<IEnumerable<GrainTypeDTO>> container = new MessageContainer<IEnumerable<GrainTypeDTO>>() { Data = result };
            return Json(container, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetGrainTypeDetails(int id)
        {
            var result = dataAccess.Get(id);
            MessageContainer<GrainTypeDTO> container = new MessageContainer<GrainTypeDTO>() { Data = result };
            return Json(container, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateGrainType(GrainTypeDTO create)
        {
            bool result = dataAccess.Create(create);
            MessageContainer<bool> container = new MessageContainer<bool>() { Data = result };
            return Json(container);
        }

        [HttpPut]
        public ActionResult UpdateGrainType(GrainTypeDTO update)
        {
            bool result = dataAccess.Update(update);
            MessageContainer<bool> container = new MessageContainer<bool>() { Data = result };
            return Json(container);
        }
        [HttpDelete]
        public ActionResult DeleteGrainType(int id)
        {
            bool result = dataAccess.Delete(id);
            MessageContainer<bool> container = new MessageContainer<bool>() { Data = result };
            return Json(container);
        }
    }
}

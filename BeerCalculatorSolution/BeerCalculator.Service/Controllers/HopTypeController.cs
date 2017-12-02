using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer.DataAccess;
using System.Web.Mvc;
using BeerCalculator.DataAccessLayer.DataAccess;
using BeerCalculator.Common.DTOs;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;
using BeerCalculator.Service.Bootstrapper;
using DataAccessLayer.DataAccess.Interface;

namespace BeerCalculatorService.Controllers
{
    public class HopTypeController : Controller
    {
        private IDataAccess<HopTypeDTO> hopTypeDataAccess;

        public HopTypeController()
        {
            ResolveDependencies();
        }

        public void ResolveDependencies()
        {
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);
            new ServiceBootstapper(container, locator);
            hopTypeDataAccess = container.Resolve<IDataAccess<HopTypeDTO>>();
        }

        [HttpGet]
        public ActionResult GetAllHopTypes()
        {
            var response = hopTypeDataAccess.Get();
            MessageContainer<IEnumerable<HopTypeDTO>> container = new MessageContainer<IEnumerable<HopTypeDTO>>() { Data = response };
            return Json(container, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetHopTypeDetails(int id)
        {
            var response = hopTypeDataAccess.Get(id);
            MessageContainer<HopTypeDTO> container = new MessageContainer<HopTypeDTO>() { Data = response };
            return Json(container, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult CreateHopType(HopTypeDTO create)
        {
            var response = hopTypeDataAccess.Create(create);
            MessageContainer<bool> container = new MessageContainer<bool>() { Data = response };
            return Json(container);
        }

        [HttpPut]
        public ActionResult UpdateHopType(HopTypeDTO update)
        {
            var response = hopTypeDataAccess.Update(update);
            MessageContainer<bool> container = new MessageContainer<bool>() { Data = response };
            return Json(container);
        }

        [HttpDelete]
        public ActionResult DeleteHopType(int delete)
        {
            var response = hopTypeDataAccess.Delete(delete);
            MessageContainer<bool> container = new MessageContainer<bool>() { Data = response };
            return Json(container);
        }
    }
}

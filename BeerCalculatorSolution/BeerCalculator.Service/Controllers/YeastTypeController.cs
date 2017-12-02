using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.DataAccess; // Use Unity and DI to remove this dependency eventually
using DataAccessLayer.DataAccess.Interface;
using BeerCalculator.Common.DTOs;
using BeerCalculator.DataAccessLayer.DataAccess;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;
using BeerCalculator.Service.Bootstrapper;

namespace BeerCalculatorService.Controllers
{
    public class YeastTypeController : Controller
    {
        private IDataAccess<YeastTypeDTO> yeastTypeDataAccess;

        public YeastTypeController()
        {
            ResolveDependencies();
        }

        public void ResolveDependencies()
        {
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);
            new ServiceBootstapper(container, locator);
            yeastTypeDataAccess = container.Resolve<IDataAccess<YeastTypeDTO>>();

        }

        [HttpGet]
        public ActionResult GetAllYeastTypes()
        {
            var yeastTypes = yeastTypeDataAccess.Get();
            var container = new MessageContainer<IEnumerable<YeastTypeDTO>>() { Data = yeastTypes };
            return Json(container, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetYeastTypeDetails(int id)
        {
            var yeastType = yeastTypeDataAccess.Get(id);
            var container = new MessageContainer<YeastTypeDTO>() { Data = yeastType };
            return Json(container, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateYeastType(YeastTypeDTO create)
        {
            var data = yeastTypeDataAccess.Create(create);
            var container = new MessageContainer<bool>() { Data = data };
            return Json(container);
        }

        [HttpPut]
        public ActionResult UpdateYeastType(YeastTypeDTO update)
        {
            var data = yeastTypeDataAccess.Update(update);
            var container = new MessageContainer<bool>() { Data = data };
            return Json(container);
        }

        [HttpDelete]
        public ActionResult DeleteYeastType(int id)
        {
            var data = yeastTypeDataAccess.Delete(id);
            var container = new MessageContainer<bool>() { Data = data };
            return Json(container);
        }
    }
}

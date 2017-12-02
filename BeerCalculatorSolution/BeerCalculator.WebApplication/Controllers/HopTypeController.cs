using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using BeerCalculator.Common.Communication;
using BeerCalculator.Common.DTOs;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;
using BeerCalculator.WebApplication.BootStrapper;

namespace BeerCalculatorWebApplication.Controllers
{
    public class HopTypeController : Controller
    {
        private IRequestManager requestManager;

        public HopTypeController()
        {
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);
            new WebAppBootStrapper(container, locator);
            requestManager = container.Resolve<IRequestManager>();
        }

        [HttpGet]
        public async Task<ActionResult> HopManagement()
        {
            var model = await requestManager.GetAll(new HopTypeDTO(), typeof(MessageContainer<IEnumerable<HopTypeDTO>>));
            return PartialView(model);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllHopTypes()
        {
            var response = await requestManager.GetAll(new HopTypeDTO(), typeof(MessageContainer<IEnumerable<HopTypeDTO>>));
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> GetHopTypeDetails(int id)
        {
            var response = await requestManager.Get(new HopTypeDTO() { HopTypeID = id }, typeof(MessageContainer<HopTypeDTO>));
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> CreateHopType(HopTypeDTO create)
        {
            var response = await requestManager.Create(create, new MessageContainer<bool>().GetType());
            return Json(response);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateHopType(HopTypeDTO update)
        {
            var response = await requestManager.Update(update, typeof(MessageContainer<bool>));
            return Json(response);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteHopType(int id)
        {
            var response = await requestManager.Delete(new HopTypeDTO() { HopTypeID = id }, typeof(MessageContainer<bool>));
            return Json(response);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using BeerCalculator.Common.DTOs;
using BeerCalculator.Common.Communication;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;
using BeerCalculator.WebApplication.BootStrapper;

namespace BeerCalculatorWebApplication.Controllers
{
    public class GrainTypeController : Controller
    {
        IRequestManager requestManager;

        public GrainTypeController()
        {
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);
            new WebAppBootStrapper(container, locator);
            requestManager = container.Resolve<IRequestManager>();
        }

        public async Task<ActionResult> GrainManagement()
        {
            var model = await requestManager.GetAll(new GrainTypeDTO(), typeof(MessageContainer<IEnumerable<GrainTypeDTO>>));

            return PartialView(model);
        }

        [HttpGet]
        public async Task<ActionResult> GetGrainTypes()
        {
            var result = await requestManager.GetAll(new GrainTypeDTO(), typeof(MessageContainer<IEnumerable<GrainTypeDTO>>));
            return Json(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetGrainTypeDetails(GrainTypeDTO details)
        {
            var result = await requestManager.Get(details, typeof(MessageContainer<GrainTypeDTO>));
            return Json(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateGrainType(GrainTypeDTO create)
        {
            var result = await requestManager.Create(create, typeof(MessageContainer<bool>));
            return Json(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateGrainType(GrainTypeDTO update)
        {
            var result = await requestManager.Update(update, typeof(MessageContainer<bool>));
            return Json(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteGrainType(GrainTypeDTO delete)
        {
            var result = await requestManager.Delete(delete, typeof(MessageContainer<bool>));
            return Json(result);
        }
    }
}

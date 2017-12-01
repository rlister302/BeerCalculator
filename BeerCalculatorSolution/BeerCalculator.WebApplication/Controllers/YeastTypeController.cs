using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using BeerCalculator.Common.Interface;
using BeerCalculator.Common.Communication;
using BeerCalculator.Common.DTOs;
using Microsoft.Practices.Unity;
using BeerCalculator.WebApplication.BootStrapper;
using Microsoft.Practices.ServiceLocation;

namespace BeerCalculatorWebApplication.Controllers
{
    public class YeastTypeController : Controller
    {
        private IRequestManager requestManager;

        public YeastTypeController()
        {
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);
            new WebAppBootStrapper(container, locator);
            requestManager = container.Resolve<IRequestManager>();
        }

        [HttpGet]
        public async Task<ActionResult> YeastManagement()
        {
            var model = await requestManager.GetAll(new YeastTypeDTO(), typeof(MessageContainer<IEnumerable<YeastTypeDTO>>));
            return PartialView(model);
        }

        [HttpGet]
        public async Task<ActionResult> GetYeastTypeDetails(int get)
        {
            YeastTypeDTO yeast = new YeastTypeDTO() { YeastTypeID = get };
            var result = await requestManager.Get(yeast, typeof(MessageContainer<YeastTypeDTO>));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> CreateYeastType(YeastTypeDTO create)
        {
            var result = await requestManager.Create(create, typeof(MessageContainer<bool>));
            return Json(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateYeastType(YeastTypeDTO update)
        {
            var result = await requestManager.Update(update, typeof(MessageContainer<bool>));
            return Json(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteYeastType(int id)
        {
            YeastTypeDTO yeast = new YeastTypeDTO() { YeastTypeID = id };
            var result = await requestManager.Delete(yeast, typeof(MessageContainer<bool>));
            return Json(result);
        }
    }
}

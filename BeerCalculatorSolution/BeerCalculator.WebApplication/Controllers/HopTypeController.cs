using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using BeerCalculator.Common.Communication;
using BeerCalculator.Common.DTOs;

namespace BeerCalculatorWebApplication.Controllers
{
    public class HopTypeController : Controller
    {
        private HopTypeRequestManager _requestManager;

        public HopTypeController()
        {
            _requestManager = new HopTypeRequestManager();
        }

        [HttpGet]
        public async Task<ActionResult> HopManagement()
        {
            var model = await _requestManager.RetreiveAll(new HopTypeDTO());
            return PartialView(model);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllHopTypes()
        {
            var response = await _requestManager.RetreiveAll(new HopTypeDTO());
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> GetHopTypeDetails(HopTypeDTO details)
        {
            var response = await _requestManager.Retreive(details);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> CreateHopType(HopTypeDTO create)
        {
            var response = await _requestManager.Create(create);
            return Json(response);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateHopType(HopTypeDTO update)
        {
            var response = await _requestManager.Update(update);
            return Json(response);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteHopType(HopTypeDTO delete)
        {
            var response = await _requestManager.Delete(delete);
            return Json(response);
        }
    }
}

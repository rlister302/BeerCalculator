using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using Common.DTOs;
using Common.Communication;

namespace BeerCalculatorWebApplication.Controllers
{
    public class HopTypeController : Controller
    {
        private HopTypeRequestManager _requestManager;

        public HopTypeController()
        {
            _requestManager = new HopTypeRequestManager();
        }

        public async Task<ActionResult> HopManagement()
        {
            var model = await _requestManager.RetreiveAll(new HopTypeDTO());
            return PartialView(model);
        }
        public async Task<ActionResult> GetAllHopTypes()
        {
            var response = await _requestManager.RetreiveAll(new HopTypeDTO());
            return Json(response);
        }
        public async Task<ActionResult> GetHopTypeDetails(HopTypeDTO details)
        {
            var response = await _requestManager.Retreive(details);
            return Json(response);
        }

        public async Task<ActionResult> CreateHopType(HopTypeDTO create)
        {
            var response = await _requestManager.Create(create);
            return Json(response);
        }

        public async Task<ActionResult> UpdateHopType(HopTypeDTO update)
        {
            var response = await _requestManager.Update(update);
            return Json(response);
        }

        public async Task<ActionResult> DeleteHopType(HopTypeDTO delete)
        {
            var response = await _requestManager.Delete(delete);
            return Json(response);
        }
    }
}

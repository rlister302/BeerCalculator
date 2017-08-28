using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using BeerCalculator.Common.DTOs;
using BeerCalculator.Common.Communication;

namespace BeerCalculatorWebApplication.Controllers
{
    public class GrainTypeController : Controller
    {
        //TODO: Implement unity via controller factory
        GrainTypeRequestManager _requestManager = new GrainTypeRequestManager();

        public async Task<ActionResult> GrainManagement()
        {
            var model = await _requestManager.RetreiveAll(new GrainTypeDTO());
            return PartialView(model);
        }

        [HttpGet]
        public async Task<ActionResult> GetGrainTypes()
        {
            var result = await _requestManager.RetreiveAll(new GrainTypeDTO());
            return Json(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetGrainTypeDetails(GrainTypeDTO details)
        {
            var result = await _requestManager.Retreive(details);
            return Json(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateGrainType(GrainTypeDTO create)
        {
            var result = await _requestManager.Create(create);
            return Json(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateGrainType(GrainTypeDTO update)
        {
            var result = await _requestManager.Update(update);
            return Json(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteGrainType(GrainTypeDTO delete)
        {
            var result = await _requestManager.Delete(delete);
            return Json(result);
        }
    }
}

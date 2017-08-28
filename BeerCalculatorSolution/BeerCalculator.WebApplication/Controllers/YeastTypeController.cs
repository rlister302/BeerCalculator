using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using BeerCalculator.Common.Interface;
using BeerCalculator.Common.Communication;
using BeerCalculator.Common.DTOs;

namespace BeerCalculatorWebApplication.Controllers
{
    public class YeastTypeController : Controller
    {
        private IRequestManager<YeastTypeDTO> yeastTypeRequestManager = new YeastTypeRequestManager();
        [HttpGet]
        public async Task<ActionResult> YeastManagement()
        {
            var model = await yeastTypeRequestManager.RetreiveAll(new YeastTypeDTO());
            return PartialView(model);
        }

        [HttpGet]
        public async Task<ActionResult> GetYeastType(YeastTypeDTO get)
        {
            var result = await yeastTypeRequestManager.Retreive(get);
            return Json(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateYeastType(YeastTypeDTO create)
        {
            var result = await yeastTypeRequestManager.Create(create);
            return Json(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateYeastType(YeastTypeDTO update)
        {
            var result = await yeastTypeRequestManager.Update(update);
            return Json(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteYeastType(YeastTypeDTO delete)
        {
            var result = await yeastTypeRequestManager.Delete(delete);
            return Json(result);
        }
    }
}

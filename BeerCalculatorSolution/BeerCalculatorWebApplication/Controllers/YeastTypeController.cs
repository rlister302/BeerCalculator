using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.DTOs;
using Common.Abstract;
using Common.Communication;
using System.Threading.Tasks;

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
        public ActionResult GetYeastType(int id)
        {
            return null;
            // call web api
        }

        [HttpPost]
        public ActionResult CreateYeastType(YeastTypeDTO create)
        {
            var x = create;

            return null;
            // call web api
        }

        [HttpPut]
        public ActionResult UpdateYeastType(YeastTypeDTO update)
        {
            return null;
            // call web api
        }

        [HttpDelete]
        public ActionResult DeleteYeastType(int id)
        {
            return null;
            // call web api
        }
    }
}

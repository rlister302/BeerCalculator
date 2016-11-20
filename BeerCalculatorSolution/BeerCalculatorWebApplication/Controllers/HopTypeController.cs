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
        public ActionResult CreateHopTypePage()
        {
            return PartialView();
        }
        public ActionResult GetAllHopTypes()
        {
            return null;
        }
        public ActionResult GetHopTypeDetails(HopTypeDTO details)
        {
            return null;
            //call web api
        }

        public async Task<ActionResult> CreateHopType(HopTypeDTO create)
        {
            var response = await new HopTypeRequestManager().Create(create);
            return Json(response);
        }

        public ActionResult UpdateHopType(HopTypeDTO update)
        {
            return null;    
            // Call web api
        }

        public ActionResult DeleteHopType(int id)
        {
            return null;
            // call web api
        }
    }
}

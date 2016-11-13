using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using Models.Models;
using Models.Communication;

namespace BeerCalculatorWebApplication.Controllers
{
    public class HopTypeController : Controller
    {
        public ActionResult HopManagement()
        {
            // call web api for hop types for grid
            return PartialView();
        }

        public ActionResult CreateHopTypePage()
        {
            return PartialView();
        }

        public ActionResult GetHopTypeDetails(int id)
        {
            return null;
            //call web api
        }

        public async Task<ActionResult> CreateHopType(HopTypeDTO create)
        {
            var response = await new HopRequestManager().Create(create);
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

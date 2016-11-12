using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Models;

namespace BeerCalculatorWebApplication.Controllers
{
    public class HopTypeController : Controller
    {
        public ActionResult GetHopTypes()
        {
            return View();
        }

        public ActionResult GetHopTypeDetails(int id)
        {
            return null;
            //call web api
        }

        public ActionResult CreateHopType(HopTypeDTO create)
        {
            return null;
            // call web api
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

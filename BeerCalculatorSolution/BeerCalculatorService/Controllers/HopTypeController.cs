using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.DTOs;

namespace BeerCalculatorService.Controllers
{
    public class HopTypeController : Controller
    {
        public ActionResult GetAllHopTypes()
        {
            return null;
        }

        public ActionResult GetHopTypeDetails(HopTypeDTO details)
        {
            return null;
        }
        
        
        public ActionResult CreateHopType(HopTypeDTO create)
        {
            create.HopTypeID = 1;
            return Json(create);
        }

        public ActionResult UpdateHopType(HopTypeDTO update)
        {
            return null;
        }

        public ActionResult DeleteHopType(HopTypeDTO delete)
        {
            return null;
        }
    }
}

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
        private DataAccess.HopTypeDataAccess _hopTypeDataAccess;
        public HopTypeController()
        {
            _hopTypeDataAccess = new DataAccess.HopTypeDataAccess();
        }

        public ActionResult GetAllHopTypes()
        {
            var response = _hopTypeDataAccess.GetAllHopTypes();
            return Json(response);
        }

        public ActionResult GetHopTypeDetails(HopTypeDTO details)
        {
            var response = _hopTypeDataAccess.GetHopTypeDetails(details);
            return Json(response);
        }
        
        public ActionResult CreateHopType(HopTypeDTO create)
        {
            var response = _hopTypeDataAccess.CreateHopType(create);
            return Json(response);
        }

        public ActionResult UpdateHopType(HopTypeDTO update)
        {
            var response = _hopTypeDataAccess.UpdateHopType(update);
            return Json(response);
        }

        public ActionResult DeleteHopType(HopTypeDTO delete)
        {
            var response = _hopTypeDataAccess.DeleteHopType(delete);
            return Json(response);
        }
    }
}

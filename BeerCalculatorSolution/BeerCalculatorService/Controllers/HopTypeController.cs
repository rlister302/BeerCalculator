using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer.DataAccess;
using System.Web.Mvc;
using Common.DTOs;

namespace BeerCalculatorService.Controllers
{
    public class HopTypeController : Controller
    {
        private HopTypeDataAccess _hopTypeDataAccess;
        public HopTypeController()
        {
            _hopTypeDataAccess = new HopTypeDataAccess();
        }
        [HttpGet]
        public ActionResult GetAllHopTypes()
        {
            var response = _hopTypeDataAccess.Get();
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetHopTypeDetails(HopTypeDTO details)
        {
            var response = _hopTypeDataAccess.Get(details);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult CreateHopType(HopTypeDTO create)
        {
            var response = _hopTypeDataAccess.Create(create);
            return Json(response);
        }

        [HttpPut]
        public ActionResult UpdateHopType(HopTypeDTO update)
        {
            var response = _hopTypeDataAccess.Update(update);
            return Json(response);
        }

        [HttpDelete]
        public ActionResult DeleteHopType(int delete)
        {
            var response = _hopTypeDataAccess.Delete(delete);
            return Json(response);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.DataAccess;
using BeerCalculator.DataAccessLayer.DataAccess;
using BeerCalculator.Common.DTOs;

namespace BeerCalculatorService.Controllers
{
    public class GrainTypeController : Controller
    {
            // TODO: Use Unity
        GrainTypeDataAccess _dataAccess = new GrainTypeDataAccess();

        [HttpGet]
        public ActionResult GetAllGrainTypes()
        {
            var result = _dataAccess.Get();
            var container = new MessageContainer<IEnumerable<GrainTypeDTO>>() { Data = result };
            return Json(container, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetGrainTypeDetails(GrainTypeDTO details)
        {
            var result = _dataAccess.Get(details);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateGrainType(GrainTypeDTO create)
        {
            bool result = _dataAccess.Create(create);
            var container = new MessageContainer<bool>() { Data = result };
            return Json(container);
        }

        [HttpPut]
        public ActionResult UpdateGrainType(GrainTypeDTO update)
        {
            bool result = _dataAccess.Update(update);
            return Json(result);
        }
        [HttpDelete]
        public ActionResult DeleteGrainType(GrainTypeDTO delete)
        {
            bool result = _dataAccess.Delete(delete.GrainTypeID);
            return Json(result);
        }
    }
}

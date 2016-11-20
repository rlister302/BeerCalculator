using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.DTOs;
using Common.Communication;

namespace BeerCalculatorService.Controllers
{
    public class GrainTypeController : Controller
    {
        public ActionResult GetAllGrainTypes()
        {
            return null;
        }

        public ActionResult GetGrainTypeDetails(GrainTypeDTO details)
        {
            return null;
        }


        public ActionResult CreateGrainType(GrainTypeDTO create)
        {
            create.GrainTypeID = 1;
            return Json(create);
        }

        public ActionResult UpdateGrainType(GrainTypeDTO update)
        {
            return null;
        }

        public ActionResult DeleteGrainType(GrainTypeDTO delete)
        {
            return null;
        }
    }
}

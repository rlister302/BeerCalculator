using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Models;

namespace BeerCalculatorService.Controllers
{
    public class HopTypeController : Controller
    {
        public ActionResult CreateHopType(HopTypeDTO create)
        {
            create.HopTypeID = 1;
            return Json(create);
        }
    }
}

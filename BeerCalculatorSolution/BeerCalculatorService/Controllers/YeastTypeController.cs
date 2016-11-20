using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.DTOs;


namespace BeerCalculatorService.Controllers
{
    public class YeastTypeController : Controller
    {
        public ActionResult GetAllYeastTypes()
        {
            return null;
        }

        public ActionResult GetYeastTypeDetails(YeastTypeDTO details)
        {
            return null;
        }


        public ActionResult CreateYeastType(YeastTypeDTO create)
        {
            create.YeastTypeID = 1;
            return Json(create);
        }

        public ActionResult UpdateYeastType(YeastTypeDTO update)
        {
            return null;
        }

        public ActionResult DeleteYeastType(YeastTypeDTO delete)
        { 
            return null;
        }
    }
}

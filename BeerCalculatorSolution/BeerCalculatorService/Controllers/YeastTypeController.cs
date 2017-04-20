using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.DTOs;
using DataAccessLayer.DataAccess; // Use Unity and DI to remove this dependency eventually
using DataAccessLayer.DataAccess.Interface;


namespace BeerCalculatorService.Controllers
{
    public class YeastTypeController : Controller
    {
        private IDataAccess<YeastTypeDTO> yeastTypeDataAccess = new YeastTypeDataAccess();
            
        public ActionResult GetAllYeastTypes()
        {
            var yeastTypes = yeastTypeDataAccess.Get();
            return Json(yeastTypes, JsonRequestBehavior.AllowGet);
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

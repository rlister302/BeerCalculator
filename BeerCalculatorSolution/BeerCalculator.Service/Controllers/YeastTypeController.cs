using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.DataAccess; // Use Unity and DI to remove this dependency eventually
using DataAccessLayer.DataAccess.Interface;
using BeerCalculator.Common.DTOs;
using BeerCalculator.DataAccessLayer.DataAccess;

namespace BeerCalculatorService.Controllers
{
    public class YeastTypeController : Controller
    {
        private IDataAccess<YeastTypeDTO> yeastTypeDataAccess = new YeastTypeDataAccess();
            
        [HttpGet]
        public ActionResult GetAllYeastTypes()
        {
            var yeastTypes = yeastTypeDataAccess.Get();
            var container = new MessageContainer<IEnumerable<YeastTypeDTO>>() { Data = yeastTypes };
            return Json(container, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetYeastTypeDetails(YeastTypeDTO details)
        {

            var yeastTypes = yeastTypeDataAccess.Get(details);
            return Json(yeastTypes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateYeastType(YeastTypeDTO create)
        {
            var data = yeastTypeDataAccess.Create(create);
            var container = new MessageContainer<bool>() { Data = data };
            return Json(container);
        }

        [HttpPut]
        public ActionResult UpdateYeastType(YeastTypeDTO update)
        {
            var data = yeastTypeDataAccess.Update(update);
            return Json(data);
        }

        [HttpDelete]
        public ActionResult DeleteYeastType(YeastTypeDTO delete)
        {
            var data = yeastTypeDataAccess.Delete(delete.YeastTypeID);
            return Json(data);
        }
    }
}

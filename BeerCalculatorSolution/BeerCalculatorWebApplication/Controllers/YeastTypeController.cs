using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Models;

namespace BeerCalculatorWebApplication.Controllers
{
    public class YeastTypeController : Controller
    {
        [HttpGet]
        public ActionResult GetYeastTypes()
        {
            return null;
            // call web api
        }

        [HttpGet]
        public ActionResult GetYeastType(int id)
        {
            return null;
            // call web api
        }

        [HttpPost]
        public ActionResult CreateYeastType(YeastTypeDTO create)
        {
            return null;
            // call web api
        }

        [HttpPut]
        public ActionResult UpdateYeastType(YeastTypeDTO update)
        {
            return null;
            // call web api
        }

        [HttpDelete]
        public ActionResult DeleteYeastType(int id)
        {
            return null;
            // call web api
        }
    }
}

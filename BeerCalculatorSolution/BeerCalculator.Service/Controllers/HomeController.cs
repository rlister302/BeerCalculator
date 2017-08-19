using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.DTOs;

namespace BeerCalculatorService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("Service has started");
        }

    }
}

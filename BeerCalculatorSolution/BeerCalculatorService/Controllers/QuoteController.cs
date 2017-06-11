using BeerCalculatorService.Quote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeerCalculatorService.Controllers
{
    public class QuoteController : Controller
    {

        IQuoteService service;
        [HttpGet]
        public ActionResult GetQuote()
        {
            service = new QuoteService();

            string value = service.GetQuote();

            return Json(value, JsonRequestBehavior.AllowGet);
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.DTOs;

namespace BeerCalculatorWebApplication.Controllers
{
    public class GrainTypeController : Controller
    {
        public ActionResult GrainManagement()
        {
            return PartialView();
        }
        public ActionResult GetGrainTypes()
        {
            return null;
            // call web api
        }

        public ActionResult GetGrainType(int id)
        {
            return null;
            // call web api
        }

        public ActionResult CreateGrainType(GrainTypeDTO create)
        {
            return null;
            // call web api
        }

        public ActionResult UpdateGrainType(GrainTypeDTO update)
        {
            return null;
            // call web api
        }

        public ActionResult DeleteGrainType(int id)
        {
            return null;
            // call web api
        }
    }
}

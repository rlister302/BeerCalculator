﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerCalculator.Common.Abstract;

namespace BeerCalculator.Common.DTOs
{
    [Controller("HopType")]
    [GetAllAction("GetAllHopTypes")]
    [GetDetailsAction("GetHopTypeDetails")]
    [CreateAction("CreateHopType")]
    [UpdateAction("UpdateHopType")]
    [DeleteAction("DeleteHopType")]
    public class HopTypeDTO : ModelBase
    {
        [PrimaryKey]
        public int HopTypeID { get; set; }
        public int HopID { get; set; }
        public string HopName { get; set; }
        public string FlavorNotes { get; set; }
        public decimal Amount { get; set; }
        public decimal AlphaAcid { get; set; }
        public int RecipeID { get; set; }
        public int BoilTime { get; set; }
    }
}

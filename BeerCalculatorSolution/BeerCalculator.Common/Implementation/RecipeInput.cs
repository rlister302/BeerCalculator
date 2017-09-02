﻿using BeerCalculator.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerCalculator.Common.DTOs;

namespace BeerCalculator.Common.Implementation
{
    public class RecipeInput : IRecipeInput
    {
        public List<GrainTypeDTO> Grains { get; set; }

        public List<HopTypeDTO> Hops { get; set; }

        public int MashEfficiency { get; set; }

        public IWaterInput WaterInput { get; set; }

        public YeastTypeDTO Yeast { get; set; }

        public int ExpectedAttenuation { get; set; }
    }
}

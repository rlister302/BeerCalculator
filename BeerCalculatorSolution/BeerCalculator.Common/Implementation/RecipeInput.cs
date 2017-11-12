using BeerCalculator.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerCalculator.Common.DTOs;
using BeerCalculator.Common.Abstract;

namespace BeerCalculator.Common.Implementation
{
    [Controller("Calculator")]
    [CreateAction("GetMetrics")]
    public class RecipeInput : ModelBase
    {
        public List<GrainTypeDTO> Grains { get; set; }

        public List<HopTypeDTO> Hops { get; set; }

        public int MashEfficiency { get; set; }

        public WaterInput WaterInput { get; set; }

        public YeastTypeDTO Yeast { get; set; }

        public int ExpectedAttenuation { get; set; }
    }
}

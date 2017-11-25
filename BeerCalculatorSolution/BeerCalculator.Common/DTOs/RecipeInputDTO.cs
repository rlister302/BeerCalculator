using BeerCalculator.Common.Abstract;
using BeerCalculator.Common.Implementation;
using BeerCalculator.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Common.DTOs
{
    [Controller("Calculator")]
    [CreateAction("GetMetrics")]
    public class RecipeInputDTO : ModelBase
    {
        public List<GrainTypeDTO> Grains { get; set; }

        public List<HopTypeDTO> Hops { get; set; }

        public int MashEfficiency { get; set; }

        public WaterInputDTO WaterInput { get; set; }

        public YeastTypeDTO Yeast { get; set; }

        public int ExpectedAttenuation { get; set; }
    }
}

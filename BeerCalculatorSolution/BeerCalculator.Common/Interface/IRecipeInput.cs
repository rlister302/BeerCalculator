using BeerCalculator.Common.DTOs;
using BeerCalculator.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Common.Interface
{
    public interface IRecipeInput
    {
        IWaterInput WaterInput { get; set; }

        List<GrainTypeDTO> Grains { get; set; }

        List<HopTypeDTO> Hops { get; set; }

        YeastTypeDTO Yeast { get; set; }

        decimal MashEfficiency { get; set; }
    }
}

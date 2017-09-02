using BeerCalculator.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Common.Interface
{
    public interface IWaterCalculator
    {
        decimal WaterRequired { get; set; }

        decimal StrikeVolume { get; set; }

        int StrikeTemperature { get; set; }

        decimal SpargeVolume { get; set; }

        decimal BoilVolume { get; set; }

        void Calculate(IWaterInput waterMetrics, List<GrainTypeDTO> grains);
    }
}

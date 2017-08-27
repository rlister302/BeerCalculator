using BeerCalculator.Common.Abstract;
using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators
{
    public interface IWaterCalculator
    {
        decimal WaterRequired { get; set; }

        decimal StrikeVolume { get; set; }

        int StrikeTemperature { get; set; }

        decimal SpargeVolume { get; set; }

        void Calculate(IWaterMetrics waterMetrics, List<GrainTypeDTO> grains, decimal boilVolume);
    }
}

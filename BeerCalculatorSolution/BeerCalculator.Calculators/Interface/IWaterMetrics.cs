using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators.Interface
{
    public interface IWaterMetrics
    {
        decimal SpargeVolume { get; set; }

        int StrikeTemperature { get; set; }

        decimal StrikeVolume { get; set; }

        decimal WaterRequired { get; set; }

        decimal BoilVolume { get; set; }
    }
}

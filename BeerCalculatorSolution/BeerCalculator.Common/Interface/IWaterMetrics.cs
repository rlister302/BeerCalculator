using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Common.Interface
{
    public interface IWaterMetrics
    {
        int WaterRequired { get; set; }

        decimal StrikeVolume { get; set; }

        int StrikeTemperature { get; set; }

        decimal SpargeVolume { get; set; }

        int SpargeTemperature { get; set; }

        decimal BoilVolume { get; set; }
    }
}

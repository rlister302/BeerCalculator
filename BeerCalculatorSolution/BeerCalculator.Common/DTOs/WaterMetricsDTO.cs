using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Common.DTOs
{
    public class WaterMetricsDTO
    {
        public int WaterRequired { get; set; }

        public decimal StrikeVolume { get; set; }

        public int StrikeTemperature { get; set; }

        public decimal SpargeVolume { get; set; }

        public int SpargeTemperature { get; set; }

        public decimal BoilVolume { get; set; }
    }
}

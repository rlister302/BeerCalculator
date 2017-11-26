using BeerCalculator.Calculators.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators.Implementation
{
    public class WaterMetrics : IWaterMetrics
    {
        public decimal SpargeVolume { get; set; }

        public int StrikeTemperature { get; set; }

        public decimal StrikeVolume { get; set; }

        public decimal WaterRequired { get; set; }

        public decimal BoilVolume { get; set; }
    }
}

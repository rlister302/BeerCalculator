using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerCalculator.Common.Interface;
using BeerCalculator.Common.DTOs;

namespace BeerCalculator.Common.Implementation
{
    public class RecipeMetricsDTO
    {
        public decimal ExpectedAbv { get; set; }

        public decimal ExpectedFinalGravity { get; set; }

        public int ExpectedIbu { get; set; }

        public decimal ExpectedOriginalGravity { get; set; }

        public decimal ExpectedBoilGravityPoints { get; set; }

        public decimal ExpectedSrm { get; set; }

        public WaterMetricsDTO WaterMetrics { get; set; }
    }
}

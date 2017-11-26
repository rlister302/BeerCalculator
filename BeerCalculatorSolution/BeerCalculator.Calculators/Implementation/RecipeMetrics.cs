using BeerCalculator.Calculators.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators.Implementation
{
    public class RecipeMetrics : IRecipeMetrics
    {
        public decimal ExpectedOriginalGravity { get; set; }

        public decimal ExpectedBoilGravityPoints { get; set; }

        public decimal ExpectedAbv { get; set; }

        public int ExpectedIbu { get; set; }

        public decimal ExpectedFinalGravity { get; set; }

        public decimal ExpectedSrm { get; set; }

        public IWaterMetrics WaterMetrics { get; set; }
    }
}

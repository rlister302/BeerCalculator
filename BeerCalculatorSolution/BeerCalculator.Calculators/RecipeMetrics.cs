using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators
{
    public class RecipeMetrics : IRecipeMetrics
    {
        public decimal ExpectedABV { get; set; }

        public decimal ExpectedFinalGravity { get; set; }

        public int ExpectedIBU { get; set; }

        public decimal ExpectedOG { get; set; }
    }
}

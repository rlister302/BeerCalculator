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
        public decimal ExpectedAbv { get; set; }

        public decimal ExpectedFinalGravity { get; set; }

        public int ExpectedIbu { get; set; }

        public decimal ExpectedOriginalGravity { get; set; }

        public decimal ExpectedBoilGravityPoints { get; set; }
    }
}

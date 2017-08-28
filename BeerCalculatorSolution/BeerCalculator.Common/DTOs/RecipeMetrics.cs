using BeerCalculator.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Common.DTOs
{
    public class RecipeMetrics : IRecipeMetrics
    {

        public decimal ExpectedOriginalGravity { get; set; }

        public decimal ExpectedAbv { get; set; }

        public int ExpectedIbu { get; set; }

        public decimal ExpectedFinalGravity { get; set; }

        public decimal ExpectedBoilGravityPoints { get; set; }

        public decimal ExpectedSrm { get; set; }

        public IWaterInput WaterMetrics { get; set; }
    }
}

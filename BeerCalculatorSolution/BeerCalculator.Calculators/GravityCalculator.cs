using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstract;
using Common.DTOs;

namespace BeerCalculator.Calculators
{
    public class GravityCalculator : IGravityCalculator
    {
        private double numberOfGallons = 5.5;
        public IRecipeMetrics Calculate(List<GrainTypeDTO> grains, int expectedEfficiency)
        {
            IRecipeMetrics metrics = new RecipeMetrics();

            decimal expectedOG = 1.000m;

            double totalGravity = 0.0;

            foreach (GrainTypeDTO grain in grains)
            {
                totalGravity += (grain.MaximumSugarExtraction * ((double)expectedEfficiency / 100));

                totalGravity *= ((double)grain.Amount);
            }

            totalGravity /= numberOfGallons;

            expectedOG += (decimal)totalGravity / 1000;

            metrics.ExpectedOG = decimal.Round(expectedOG, 3);
            return metrics;
        }
    }
}

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
        //TODO: Make this come from the recipe...
        private double numberOfGallons = 5.5;

        private const int thousandthDivider = 1000;


        public decimal Calculate(List<GrainTypeDTO> grains, int expectedEfficiency)
        {
            decimal expectedOG = 1.000m;

            double totalGravity = 0.0;

            foreach (GrainTypeDTO grain in grains)
            {
                totalGravity += (grain.MaximumSugarExtraction * ((double)expectedEfficiency / 100));

                totalGravity *= ((double)grain.Amount);
            }

            totalGravity /= numberOfGallons;

            expectedOG += (decimal)totalGravity / thousandthDivider;

            return decimal.Round(expectedOG, 3);
        }
    }
}

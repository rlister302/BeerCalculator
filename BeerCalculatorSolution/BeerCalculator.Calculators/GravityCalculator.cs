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

        //private double boilVolume = 6.5;

        private const int thousandthDivider = 1000;

        public decimal TotalGravityPoints { get; set; }

        public decimal OriginalGravity { get; set; }


        public void Calculate(List<GrainTypeDTO> grains, int expectedEfficiency)
        {
            CalculateOriginalGravity(grains, expectedEfficiency);
            CalculateBoilGravityPoints(grains, expectedEfficiency);
        }

        private void CalculateOriginalGravity(List<GrainTypeDTO> grains, int expectedEfficiency)
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

            OriginalGravity = decimal.Round(expectedOG, 3);

        }

        public void CalculateBoilGravityPoints(List<GrainTypeDTO> grains, int expectedEfficiency)
        {
            decimal boilPoints = decimal.Zero;

            double points = 0.0;

            foreach (GrainTypeDTO grain in grains)
            {
                points += ((grain.MaximumSugarExtraction * ((double)expectedEfficiency / 100)) * (double)grain.Amount);
            }


            boilPoints = (decimal)(points / 6.5);

            TotalGravityPoints = decimal.Round(boilPoints, 2);
        }
    }
}

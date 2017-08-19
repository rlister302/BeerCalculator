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
        private const int thousandthDivider = 1000;

        public decimal BoilGravityPoints { get; set; }

        public decimal OriginalGravity { get; set; }

        public double BoilVolume { get; set; }

        public double FinalVolume { get; set; }

        public void Calculate(List<GrainTypeDTO> grains, int expectedEfficiency, double boilVolume = 6.5, double finalVolume = 5.5)
        {
            BoilVolume = boilVolume;
            FinalVolume = finalVolume;
            CalculateOriginalGravity(grains, expectedEfficiency);
            CalculateBoilGravityPoints(grains, expectedEfficiency);
        }

        private void CalculateOriginalGravity(List<GrainTypeDTO> grains, int expectedEfficiency)
        {
            decimal expectedOG = 1.000m;

            double totalGravity = 0.0;

            foreach (GrainTypeDTO grain in grains)
            {
                double expectedExtraction = (grain.MaximumSugarExtraction * (expectedEfficiency / 100.0));

                totalGravity += (expectedExtraction * (double)grain.Amount); 
            }

            totalGravity /= FinalVolume;

            expectedOG += (decimal)totalGravity / thousandthDivider;

            OriginalGravity = decimal.Round(expectedOG, 3);

        }

        public void CalculateBoilGravityPoints(List<GrainTypeDTO> grains, int expectedEfficiency)
        {
            decimal boilPoints = decimal.Zero;

            double points = 0.0;

            foreach (GrainTypeDTO grain in grains)
            {
                double expectedExtraction = (grain.MaximumSugarExtraction * (expectedEfficiency / 100.0));

                double totalGravity = (expectedExtraction * (double)grain.Amount);

                points += totalGravity;
            }


            boilPoints = (decimal)(points / BoilVolume);

            BoilGravityPoints = decimal.Round(boilPoints, 2);
        }
    }
}

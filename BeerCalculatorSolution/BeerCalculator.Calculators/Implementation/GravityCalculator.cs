using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerCalculator.Common.Interface;
using BeerCalculator.Common.DTOs;
using BeerCalculator.Calculators.Interface;

namespace BeerCalculator.Calculators.Implementation
{
    public class GravityCalculator : IGravityCalculator
    {
        private const int thousandthDivider = 1000;

        public decimal BoilGravityPoints { get; set; }

        public decimal OriginalGravity { get; set; }

        public decimal BoilVolume { get; set; }

        public decimal FinalVolume { get; set; }

        public void Calculate(List<IGrain> grains, int expectedEfficiency, decimal boilVolume = 6.5m, decimal finalVolume = 5.5m)
        {
            BoilVolume = boilVolume;
            FinalVolume = finalVolume;
            CalculateOriginalGravity(grains, expectedEfficiency);
            CalculateBoilGravityPoints(grains, expectedEfficiency);
        }

        private void CalculateOriginalGravity(List<IGrain> grains, int expectedEfficiency)
        {
            decimal expectedOG = 1.000m;

            decimal totalGravity = 0.0m;

            foreach (IGrain grain in grains)
            {
                decimal expectedExtraction = (grain.MaximumSugarExtraction * (expectedEfficiency / 100.0m));

                totalGravity += (expectedExtraction * grain.Amount); 
            }

            totalGravity /= FinalVolume;

            expectedOG += (decimal)totalGravity / thousandthDivider;

            OriginalGravity = decimal.Round(expectedOG, 3);

        }

        public void CalculateBoilGravityPoints(List<IGrain> grains, int expectedEfficiency)
        {
            decimal boilPoints = decimal.Zero;

            decimal points = 0.0m;

            foreach (IGrain grain in grains)
            {
                decimal expectedExtraction = (grain.MaximumSugarExtraction * (expectedEfficiency / 100.0m));

                decimal totalGravity = (expectedExtraction * grain.Amount);

                points += totalGravity;
            }


            boilPoints = (decimal)(points / BoilVolume);

            BoilGravityPoints = decimal.Round(boilPoints, 2);
        }
    }
}

using BeerCalculator.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators
{
    public class AttenuationCalculator : IAttenuationCalculator
    {
        public decimal FinalGravity { get; set; }

        public decimal Calculate(decimal originalGravity, int expectedAttenuationRate)
        {
            double ratio = 1.0 - (expectedAttenuationRate / 100.0);
            decimal calculatedGravity = 1.000m + ((originalGravity * (decimal)(ratio)) / 1000);
            FinalGravity = decimal.Round(calculatedGravity, 3);
            return decimal.Round(calculatedGravity, 3); 
        }

        private int GetWholeNumberSugarLevel(int originalGravity)
        {
            int gravity = originalGravity % 1000;

            return gravity;
        }

        private double GetAttenuationRate(int expectedAttenuationRate)
        {
            double attenuationRatio = (double)expectedAttenuationRate / 100;

            return attenuationRatio;
        }

        private int GetWholeNumberGravity(decimal originalGravity)
        {
            int wholeNumberGravity = (int)(originalGravity * 1000);

            return wholeNumberGravity;
        }
    }
}

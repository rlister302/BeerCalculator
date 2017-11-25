using BeerCalculator.Calculators.Interface;
using BeerCalculator.Common.DTOs;
using BeerCalculator.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BeerCalculator.Calculators.Implementation
{
    public class SrmCalculator : ISrmCalculator
    {
        public decimal ExpectedSrm { get; set; }

        public decimal ExpectedMcu { get; set; }

        public SrmCalculator()
        {
            ExpectedSrm = 0.0m;
            ExpectedMcu = 0.0m;
        }

        public void Calculate(List<IGrain> grains, decimal batchSize)
        {
            ExpectedSrm = 0.0m;
            ExpectedMcu = 0.0m;
            CalculateMcu(grains, batchSize);
            CalculateSrm();
        }

        private void CalculateMcu(List<IGrain> grains, decimal batchSize)
        {
            foreach (IGrain grain in grains)
            {
                decimal mcuContribution = grain.Lovibond * grain.Amount;
                decimal mcuContributionOverBatch = mcuContribution / batchSize;
                ExpectedMcu += decimal.Round(mcuContributionOverBatch, 2);
            }
        }

        private void CalculateSrm()
        {
            double magicNumber = Math.Pow((double)ExpectedMcu, 0.6859);
            double secondMagicNumber = 1.4922 * magicNumber;
            ExpectedSrm = decimal.Round((decimal)secondMagicNumber, 2);
        }
    }
}

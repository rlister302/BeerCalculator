using BeerCalculator.Common.Abstract;
using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators
{
    public class WaterCalculator : IWaterCalculator
    {
        public decimal SpargeVolume { get; set; }

        public int StrikeTemperature { get; set; }

        public decimal StrikeVolume { get; set; }

        public decimal WaterRequired { get; set; }

        private decimal totalGrain;

        public void Calculate(IWaterMetrics waterMetrics, List<GrainTypeDTO> grains, decimal boilVolume)
        {
            totalGrain = grains.Sum(x => x.Amount);
            CalculateStrikeVolume(waterMetrics, grains);
            CalculateStrikeTemperature(waterMetrics, grains);
            CalculateSpargeVolume(waterMetrics, boilVolume);
            CalculateWaterRequired();
        }

        private void CalculateStrikeVolume(IWaterMetrics waterMetrics, List<GrainTypeDTO> grains)
        {
            
            decimal conversion = waterMetrics.MashThickness / 4;
            StrikeVolume = totalGrain * conversion;
        }

        private void CalculateStrikeTemperature(IWaterMetrics waterMetrics, List<GrainTypeDTO> grains)
        {
            decimal thicknessConversion = .2m / waterMetrics.MashThickness;
            decimal grainTemperatureCompensation = waterMetrics.MashTemperature - waterMetrics.InitialGrainTemperature;
            decimal magicNumber = thicknessConversion * grainTemperatureCompensation;
            StrikeTemperature = (int)(decimal.Round(magicNumber + waterMetrics.MashTemperature));
        }

        private void CalculateSpargeVolume(IWaterMetrics waterMetrics, decimal boilVolume)
        {
            decimal grainAbsorbtion = waterMetrics.GrainAbsorbtion * totalGrain;
            decimal equipmentAndGrainLoss = waterMetrics.EquipmentDeadSpace + grainAbsorbtion;
            decimal strikeDifference = StrikeVolume - equipmentAndGrainLoss;
            SpargeVolume = boilVolume - strikeDifference;
        }

        private void CalculateWaterRequired()
        {
            decimal rawValue = StrikeVolume + SpargeVolume;
            
            WaterRequired = Math.Ceiling(rawValue);
        }
    }
}

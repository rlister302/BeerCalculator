using BeerCalculator.Calculators.Interface;
using BeerCalculator.Common.Abstract;
using BeerCalculator.Common.DTOs;
using BeerCalculator.Common.Implementation;
using BeerCalculator.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators.Implementation
{
    public class WaterCalculator : IWaterCalculator
    {
        //public decimal SpargeVolume { get; set; }

        //public int StrikeTemperature { get; set; }

        //public decimal StrikeVolume { get; set; }

        //public decimal WaterRequired { get; set; }

        //public decimal BoilVolume { get; set; }

        private decimal totalGrain;

        private const decimal boilTime = 60m;

        public IWaterMetrics Calculate(IWaterInput waterInput, List<IGrain> grains)
        {
            WaterMetrics waterMetrics = new WaterMetrics();
            totalGrain = grains.Sum(x => x.Amount);
            waterMetrics.BoilVolume = CalculateBoilVolume(waterInput);
            waterMetrics.StrikeVolume = CalculateStrikeVolume(waterInput, grains);
            waterMetrics.StrikeTemperature = CalculateStrikeTemperature(waterInput, grains);
            waterMetrics.SpargeVolume = CalculateSpargeVolume(waterInput, waterMetrics.BoilVolume, waterMetrics.StrikeVolume);
            waterMetrics.WaterRequired = CalculateWaterRequired(waterMetrics.StrikeVolume, waterMetrics.SpargeVolume);
            return waterMetrics;
        }

        private decimal CalculateStrikeVolume(IWaterInput waterInput, List<IGrain> grains)
        {
            decimal conversion = waterInput.MashThickness / 4;
            decimal strikeVolume = totalGrain * conversion;
            return strikeVolume;
        }

        private int CalculateStrikeTemperature(IWaterInput waterInput, List<IGrain> grains)
        {
            decimal thicknessConversion = .2m / waterInput.MashThickness;
            decimal grainTemperatureCompensation = waterInput.MashTemperature - waterInput.InitialGrainTemperature;
            decimal magicNumber = thicknessConversion * grainTemperatureCompensation;
            int strikeTemperature = (int)(decimal.Round(magicNumber + waterInput.MashTemperature));
            return strikeTemperature;
        }

        private decimal CalculateSpargeVolume(IWaterInput waterInput, decimal boilVolume, decimal strikeVolume)
        {
            decimal grainAbsorbtion = waterInput.GrainAbsorbtion * totalGrain;
            decimal equipmentAndGrainLoss = waterInput.EquipmentDeadSpace + grainAbsorbtion;
            decimal strikeDifference = strikeVolume - equipmentAndGrainLoss;
            decimal spargeVolume = boilVolume - strikeDifference;
            return spargeVolume;
        }

        private decimal CalculateWaterRequired(decimal strikeVolume, decimal spargeVolume)
        {
            decimal rawValue = strikeVolume + spargeVolume;
            decimal waterRequired = Math.Ceiling(rawValue);
            return waterRequired;
        }

        private decimal CalculateBoilVolume(IWaterInput waterInput)
        {
            decimal boilMetrics = waterInput.BoilRate * (boilTime / 60m);
            decimal boilVolume = waterInput.DesiredBatchSize + boilMetrics + waterInput.TrubLoss;
            return boilVolume;
        }
    }
}

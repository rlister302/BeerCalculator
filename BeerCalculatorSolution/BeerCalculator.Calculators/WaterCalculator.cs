﻿using BeerCalculator.Common.Abstract;
using BeerCalculator.Common.DTOs;
using BeerCalculator.Common.Implementation;
using BeerCalculator.Common.Interface;
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

        public decimal BoilVolume { get; set; }

        private decimal totalGrain;

        private const decimal boilTime = 60m;

        public void Calculate(WaterInputDTO waterInput, List<GrainTypeDTO> grains)
        {
            totalGrain = grains.Sum(x => x.Amount);
            CalculateBoilVolume(waterInput);
            CalculateStrikeVolume(waterInput, grains);
            CalculateStrikeTemperature(waterInput, grains);
            CalculateSpargeVolume(waterInput, BoilVolume);
            CalculateWaterRequired();
        }

        private void CalculateStrikeVolume(WaterInputDTO waterInput, List<GrainTypeDTO> grains)
        {
            
            decimal conversion = waterInput.MashThickness / 4;
            StrikeVolume = totalGrain * conversion;
        }

        private void CalculateStrikeTemperature(WaterInputDTO waterInput, List<GrainTypeDTO> grains)
        {
            decimal thicknessConversion = .2m / waterInput.MashThickness;
            decimal grainTemperatureCompensation = waterInput.MashTemperature - waterInput.InitialGrainTemperature;
            decimal magicNumber = thicknessConversion * grainTemperatureCompensation;
            StrikeTemperature = (int)(decimal.Round(magicNumber + waterInput.MashTemperature));
        }

        private void CalculateSpargeVolume(WaterInputDTO waterInput, decimal boilVolume)
        {
            decimal grainAbsorbtion = waterInput.GrainAbsorbtion * totalGrain;
            decimal equipmentAndGrainLoss = waterInput.EquipmentDeadSpace + grainAbsorbtion;
            decimal strikeDifference = StrikeVolume - equipmentAndGrainLoss;
            SpargeVolume = boilVolume - strikeDifference;
        }

        private void CalculateWaterRequired()
        {
            decimal rawValue = StrikeVolume + SpargeVolume;
            
            WaterRequired = Math.Ceiling(rawValue);
        }

        private void CalculateBoilVolume(WaterInputDTO waterInput)
        {
            // batch size + (boilRate * (boilTime / 60)) + TrubLoss
            decimal boilMetrics = waterInput.BoilRate * (boilTime / 60m);
            BoilVolume = waterInput.DesiredBatchSize + boilMetrics + waterInput.TrubLoss;
        }
    }
}

using BeerCalculator.Calculators.Interface;
using BeerCalculator.Common.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerCalculator.Common.DTOs;

namespace BeerCalculator.Service.Converter
{
    public static class Extensions
    {
        public static RecipeMetricsDTO ToDTO(this IRecipeMetrics metrics)
        {
            RecipeMetricsDTO metricsToReturn = new RecipeMetricsDTO();
            metricsToReturn.ExpectedAbv = metrics.ExpectedAbv;
            metricsToReturn.ExpectedBoilGravityPoints = metrics.ExpectedBoilGravityPoints;
            metricsToReturn.ExpectedFinalGravity = metrics.ExpectedFinalGravity;
            metricsToReturn.ExpectedIbu = metrics.ExpectedIbu;
            metricsToReturn.ExpectedSrm = metrics.ExpectedSrm;
            metricsToReturn.ExpectedOriginalGravity = metrics.ExpectedOriginalGravity;
            metricsToReturn.WaterMetrics = ConvertWaterMetrics(metrics.WaterMetrics);

            return metricsToReturn;
        }

        private static WaterMetricsDTO ConvertWaterMetrics(IWaterMetrics waterMetrics)
        {
            WaterMetricsDTO dto = new WaterMetricsDTO();
            dto.BoilVolume = waterMetrics.BoilVolume;
            dto.SpargeVolume = waterMetrics.SpargeVolume;
            dto.StrikeTemperature = waterMetrics.StrikeTemperature;
            dto.StrikeVolume = waterMetrics.StrikeVolume;
            dto.WaterRequired = waterMetrics.WaterRequired;
            return dto;
        }
    }
}
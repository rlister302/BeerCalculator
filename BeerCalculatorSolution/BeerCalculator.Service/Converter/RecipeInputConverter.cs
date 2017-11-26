using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerCalculator.Calculators.Interface;
using BeerCalculator.Common.DTOs;
using BeerCalculator.Common.Implementation;
using BeerCalculator.Calculators.Implementation;

namespace BeerCalculator.Service.Converter
{
    public class RecipeInputConverter : IConverter
    {
        public IRecipeInput Convert(RecipeInputDTO input)
        {
            IRecipeInput converted = new RecipeInput();
            converted.ExpectedAttenuation = input.ExpectedAttenuation;
            converted.Grains = ConvertGrains(input.Grains);
            converted.Hops = ConvertHops(input.Hops);
            converted.MashEfficiency = input.MashEfficiency;
            converted.WaterInput = ConvertWaterInput(input.WaterInput);

            return converted;
        }

        private List<IGrain> ConvertGrains(List<GrainTypeDTO> grains)
        {
            List<IGrain> grainToReturn = new List<IGrain>();

            foreach (GrainTypeDTO grain in grains)
            {
                IGrain g = new Grain();
                g.Amount = grain.Amount;
                g.Lovibond = grain.Lovibond;
                g.MaximumExtractionRate = grain.MaximumExtractionRate;
                g.MaximumSugarExtraction = grain.MaximumSugarExtraction;
                grainToReturn.Add(g);


            }

            return grainToReturn;
        }

        private List<IHop> ConvertHops(List<HopTypeDTO> hops)
        {
            List<IHop> hopsToReturn = new List<IHop>();

            foreach (HopTypeDTO hop in hops)
            {
                IHop h = new Hop();
                h.AlphaAcid = hop.AlphaAcid;
                h.Amount = hop.Amount;
                h.BoilTime = hop.BoilTime;
                hopsToReturn.Add(h);
            }

            return hopsToReturn;
        }

        private IWaterInput ConvertWaterInput(WaterInputDTO input)
        {
            IWaterInput w = new WaterInput();
            w.BoilRate = input.BoilRate;
            w.DesiredBatchSize = input.DesiredBatchSize;
            w.EquipmentDeadSpace = input.EquipmentDeadSpace;
            w.GrainAbsorbtion = input.GrainAbsorbtion;
            w.MashTemperature = input.MashTemperature;
            w.MashThickness = input.MashThickness;
            w.TrubLoss = input.TrubLoss;
            w.InitialGrainTemperature = input.InitialGrainTemperature;
            return w;

        }
    }
}
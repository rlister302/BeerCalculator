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
    public class BeerMetricsCalculator : IBeerMetricsCalculator
    {
        public IAbvCalculator AbvCalculator { get; set; }

        public IAttenuationCalculator AttenuationCalculator { get; set; }

        public IGravityCalculator GravityCalculator { get; set; }

        public IIbuCalculator IbuCalculator { get; set; }

        public ISrmCalculator SrmCalculator { get; set; }

        public IWaterCalculator WaterCalculator { get; set; }

        public IRecipeMetaDataResolver MetaDataResolver { get; set; }

        public BeerMetricsCalculator(IAbvCalculator abvCalculator, IAttenuationCalculator attenuationCalculator, IGravityCalculator gravityCalculator, IIbuCalculator ibuCalculator, ISrmCalculator srmCalculator, IWaterCalculator waterCalculator)
        {
            AbvCalculator = abvCalculator;
            AttenuationCalculator = attenuationCalculator;
            GravityCalculator = gravityCalculator;
            IbuCalculator = ibuCalculator;
            SrmCalculator = srmCalculator;
            WaterCalculator = waterCalculator;
        }

        public IRecipeMetrics Calculate(RecipeInput recipeInput)
        {
            IRecipeMetrics metrics = new RecipeMetrics();

            WaterCalculator.Calculate(recipeInput.WaterInput, recipeInput.Grains);
            GravityCalculator.Calculate(recipeInput.Grains, recipeInput.MashEfficiency, WaterCalculator.BoilVolume, recipeInput.WaterInput.DesiredBatchSize);
            IbuCalculator.Calculate(recipeInput.Hops, GravityCalculator.OriginalGravity);
            AttenuationCalculator.Calculate(GravityCalculator.BoilGravityPoints, recipeInput.ExpectedAttenuation);
            AbvCalculator.Calculate(GravityCalculator.OriginalGravity, AttenuationCalculator.FinalGravity);
            SrmCalculator.Calculate(recipeInput.Grains, recipeInput.WaterInput.DesiredBatchSize);


            metrics.ExpectedOriginalGravity = GravityCalculator.OriginalGravity;
            metrics.ExpectedIbu = IbuCalculator.ExpectedIbu;
            metrics.ExpectedFinalGravity = AttenuationCalculator.FinalGravity;
            metrics.ExpectedAbv = AbvCalculator.ExpectedAbv;
            metrics.ExpectedBoilGravityPoints = GravityCalculator.BoilGravityPoints;
            metrics.ExpectedSrm = SrmCalculator.ExpectedSrm;

            return metrics;
        }
    }
}

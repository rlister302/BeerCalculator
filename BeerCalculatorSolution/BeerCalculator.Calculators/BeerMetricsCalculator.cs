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
    public class BeerMetricsCalculator : AbstractBeerMetricsCalculator
    {
        public BeerMetricsCalculator(IAbvCalculator abvCalculator, IAttenuationCalculator attenuationCalculator, IGravityCalculator gravityCalculator, IIbuCalculator ibuCalculator, ISrmCalculator srmCalculator, IWaterCalculator waterCalculator) : base(abvCalculator, attenuationCalculator, gravityCalculator, ibuCalculator, srmCalculator, waterCalculator)
        {
            AbvCalculator = abvCalculator;
            AttenuationCalculator = attenuationCalculator;
            GravityCalculator = gravityCalculator;
            IbuCalculator = ibuCalculator;
            SrmCalculator = srmCalculator;
            WaterCalculator = waterCalculator;
        }

        public override RecipeMetricsDTO Calculate(RecipeInputDTO recipeInput)
        {
            RecipeMetricsDTO metrics = new RecipeMetricsDTO();
            CalculateAllMetrics(recipeInput);
            SetMetrics(metrics);
            return metrics;
        }

        private void CalculateAllMetrics(RecipeInputDTO recipeInput)
        {
            WaterCalculator.Calculate(recipeInput.WaterInput, recipeInput.Grains);
            GravityCalculator.Calculate(recipeInput.Grains, recipeInput.MashEfficiency, WaterCalculator.BoilVolume, recipeInput.WaterInput.DesiredBatchSize);
            IbuCalculator.Calculate(recipeInput.Hops, GravityCalculator.OriginalGravity);
            AttenuationCalculator.Calculate(GravityCalculator.BoilGravityPoints, recipeInput.ExpectedAttenuation);
            AbvCalculator.Calculate(GravityCalculator.OriginalGravity, AttenuationCalculator.FinalGravity);
            SrmCalculator.Calculate(recipeInput.Grains, recipeInput.WaterInput.DesiredBatchSize);
        }

        private void SetMetrics(RecipeMetricsDTO metrics)
        {
            metrics.ExpectedOriginalGravity = GravityCalculator.OriginalGravity;
            metrics.ExpectedIbu = IbuCalculator.ExpectedIbu;
            metrics.ExpectedFinalGravity = AttenuationCalculator.FinalGravity;
            metrics.ExpectedAbv = AbvCalculator.ExpectedAbv;
            metrics.ExpectedBoilGravityPoints = GravityCalculator.BoilGravityPoints;
            metrics.ExpectedSrm = SrmCalculator.ExpectedSrm;
        }
    }
}

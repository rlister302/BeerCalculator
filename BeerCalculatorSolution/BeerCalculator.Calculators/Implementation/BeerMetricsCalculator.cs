using BeerCalculator.Calculators.Implementation;
using BeerCalculator.Calculators.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BeerCalculator.Calculators.Implementation
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

        public override IRecipeMetrics Calculate(IRecipeInput recipeInput)
        {
            IRecipeMetrics metrics = CalculateAllMetrics(recipeInput);
            return metrics;
        }

        private IRecipeMetrics CalculateAllMetrics(IRecipeInput recipeInput)
        {
            IRecipeMetrics recipeMetrics = new RecipeMetrics();
            IWaterMetrics waterMetrics = WaterCalculator.Calculate(recipeInput.WaterInput, recipeInput.Grains);
            GravityCalculator.Calculate(recipeInput.Grains, recipeInput.MashEfficiency, waterMetrics.BoilVolume, recipeInput.WaterInput.DesiredBatchSize);
            IbuCalculator.Calculate(recipeInput.Hops, GravityCalculator.OriginalGravity);
            AttenuationCalculator.Calculate(GravityCalculator.BoilGravityPoints, recipeInput.ExpectedAttenuation);
            AbvCalculator.Calculate(GravityCalculator.OriginalGravity, AttenuationCalculator.FinalGravity);
            SrmCalculator.Calculate(recipeInput.Grains, recipeInput.WaterInput.DesiredBatchSize);
            SetMetrics(recipeMetrics, waterMetrics);
            return recipeMetrics;
        }

        private void SetMetrics(IRecipeMetrics metrics, IWaterMetrics waterMetrics)
        {
            metrics.ExpectedOriginalGravity = GravityCalculator.OriginalGravity;
            metrics.ExpectedIbu = IbuCalculator.ExpectedIbu;
            metrics.ExpectedFinalGravity = AttenuationCalculator.FinalGravity;
            metrics.ExpectedAbv = AbvCalculator.ExpectedAbv;
            metrics.ExpectedBoilGravityPoints = GravityCalculator.BoilGravityPoints;
            metrics.ExpectedSrm = SrmCalculator.ExpectedSrm;
            metrics.WaterMetrics = waterMetrics;
        }
    }
}

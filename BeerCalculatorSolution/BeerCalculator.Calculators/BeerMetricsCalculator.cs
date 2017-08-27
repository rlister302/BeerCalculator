using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstract;
using Common.DTOs;

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

        public BeerMetricsCalculator(IAbvCalculator abvCalculator, IAttenuationCalculator attenuationCalculator, IGravityCalculator gravityCalculator, IIbuCalculator ibuCalculator, ISrmCalculator srmCalculator, IWaterCalculator waterCalculator)
        {
            AbvCalculator = abvCalculator;
            AttenuationCalculator = attenuationCalculator;
            GravityCalculator = gravityCalculator;
            IbuCalculator = ibuCalculator;
            SrmCalculator = srmCalculator;
            WaterCalculator = waterCalculator;
        }

        public IRecipeMetrics Calculate(RecipeDTO recipe)
        {
            IRecipeMetrics metrics = new RecipeMetrics();

            GravityCalculator.Calculate(recipe.Grains, recipe.MashEfficiency, recipe.BoilVolume, recipe.FinalVolume);
            IbuCalculator.Calculate(recipe.Hops, GravityCalculator.OriginalGravity);
            AttenuationCalculator.Calculate(GravityCalculator.BoilGravityPoints, recipe.ExpectedAttenuation);
            AbvCalculator.Calculate(GravityCalculator.OriginalGravity, AttenuationCalculator.FinalGravity);
            SrmCalculator.Calculate(recipe.Grains, recipe.FinalVolume);
            WaterCalculator.Calculate(recipe.WaterMetrics, recipe.Grains, GravityCalculator.BoilVolume);

            metrics.ExpectedOriginalGravity = GravityCalculator.OriginalGravity;
            metrics.ExpectedIbu = IbuCalculator.ExpectedIbu;
            metrics.ExpectedFinalGravity = AttenuationCalculator.FinalGravity;
            metrics.ExpectedAbv = AbvCalculator.ExpectedAbv;
            metrics.ExpectedBoilGravityPoints = GravityCalculator.BoilGravityPoints;

            return metrics;
        }
    }
}

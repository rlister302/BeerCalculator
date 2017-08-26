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

        public BeerMetricsCalculator(IAbvCalculator abvCalculator, IAttenuationCalculator attenuationCalculator, IGravityCalculator gravityCalculator, IIbuCalculator ibuCalculator)
        {
            AbvCalculator = abvCalculator;
            AttenuationCalculator = attenuationCalculator;
            GravityCalculator = gravityCalculator;
            IbuCalculator = ibuCalculator;
        }

        public IRecipeMetrics Calculate(RecipeDTO recipe)
        {
            IRecipeMetrics metrics = new RecipeMetrics();

            GravityCalculator.Calculate(recipe.Grains, recipe.MashEfficiency, (double)recipe.BoilVolume, (double)recipe.FinalVolume);
            IbuCalculator.Calculate(recipe.Hops, GravityCalculator.OriginalGravity);
            AttenuationCalculator.Calculate(GravityCalculator.BoilGravityPoints, recipe.ExpectedAttenuation);
            AbvCalculator.Calculate(GravityCalculator.OriginalGravity, AttenuationCalculator.FinalGravity);

            metrics.ExpectedOriginalGravity = GravityCalculator.OriginalGravity;
            metrics.ExpectedIbu = IbuCalculator.ExpectedIbu;
            metrics.ExpectedFinalGravity = AttenuationCalculator.FinalGravity;
            metrics.ExpectedAbv = AbvCalculator.ExpectedAbv;
            metrics.ExpectedBoilGravityPoints = GravityCalculator.BoilGravityPoints;

            return metrics;
        }
    }
}

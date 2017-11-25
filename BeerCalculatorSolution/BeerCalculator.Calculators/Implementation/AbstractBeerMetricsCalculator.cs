using BeerCalculator.Calculators.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators.Implementation
{

    public abstract class AbstractBeerMetricsCalculator : IBeerMetricsCalculator
    {
        protected IAbvCalculator AbvCalculator { get; set; }

        protected IGravityCalculator GravityCalculator { get; set; }

        protected IAttenuationCalculator AttenuationCalculator { get; set; }

        protected IIbuCalculator IbuCalculator { get; set; }

        protected ISrmCalculator SrmCalculator { get; set; }

        protected IWaterCalculator WaterCalculator { get; set; }

        public abstract IRecipeMetrics Calculate(IRecipeInput recipeInput);

        public AbstractBeerMetricsCalculator(IAbvCalculator abvCalculator, IAttenuationCalculator attenuationCalculator, IGravityCalculator gravityCalculator, IIbuCalculator ibuCalculator, ISrmCalculator srmCalculator, IWaterCalculator waterCalculator)
        {
            AbvCalculator = abvCalculator;
            AttenuationCalculator = attenuationCalculator;
            GravityCalculator = gravityCalculator;
            IbuCalculator = ibuCalculator;
            SrmCalculator = srmCalculator;
            WaterCalculator = waterCalculator;
        }
    }
}

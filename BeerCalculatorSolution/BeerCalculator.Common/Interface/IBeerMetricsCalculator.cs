using BeerCalculator.Common.DTOs;
using BeerCalculator.Common.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Common.Interface
{
    public interface IBeerMetricsCalculator
    {
        IAbvCalculator AbvCalculator { get; set; }
        IGravityCalculator GravityCalculator { get; set; }

        IAttenuationCalculator AttenuationCalculator { get; set;}

        IIbuCalculator IbuCalculator { get; set; }

        ISrmCalculator SrmCalculator { get; set; }

        IWaterCalculator WaterCalculator { get; set; }

        IRecipeMetrics Calculate(RecipeInput recipeInput);
    }
}

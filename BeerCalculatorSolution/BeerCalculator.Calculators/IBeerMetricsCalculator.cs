using Common.Abstract;
using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators
{
    public interface IBeerMetricsCalculator
    {
        IAbvCalculator AbvCalculator { get; set; }
        IGravityCalculator GravityCalculator { get; set; }

        IAttenuationCalculator AttenuationCalculator { get; set;}

        IIbuCalculator IbuCalculator { get; set; }

        IRecipeMetrics Calculate(RecipeDTO recipe);

   


    }
}

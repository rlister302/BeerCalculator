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
        RecipeMetricsDTO Calculate(RecipeInputDTO recipeInput);
    }
}

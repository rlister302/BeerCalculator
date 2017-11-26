using BeerCalculator.Calculators.Interface;
using BeerCalculator.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Service.Converter
{
    public interface IConverter
    {
        IRecipeInput Convert(RecipeInputDTO input);
    }
}

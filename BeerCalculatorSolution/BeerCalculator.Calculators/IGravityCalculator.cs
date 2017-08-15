using Common.Abstract;
using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators
{
    public interface IGravityCalculator
    {
        IRecipeMetrics Calculate(List<GrainTypeDTO> grains, int expectedEfficiency);
    }
}

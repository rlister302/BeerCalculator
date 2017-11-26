using BeerCalculator.Common.DTOs;
using BeerCalculator.Common.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators.Interface
{
    public interface IWaterCalculator
    {
        IWaterMetrics Calculate(IWaterInput waterMetrics, List<IGrain> grains);
    }
}

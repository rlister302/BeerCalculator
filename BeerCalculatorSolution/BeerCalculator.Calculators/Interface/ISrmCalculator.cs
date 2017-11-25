using BeerCalculator.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators.Interface
{
    public interface ISrmCalculator
    {
        decimal ExpectedSrm { get; set; }

        decimal ExpectedMcu { get; set; }

        void Calculate(List<IGrain> grains, decimal batchSize);
    }
}

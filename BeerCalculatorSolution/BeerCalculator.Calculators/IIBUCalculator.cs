using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators
{
    public interface IIBUCalculator
    {
        int Calculate(List<HopDTO> hops);
    }
}

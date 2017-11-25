using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators.Interface
{
    public interface IIbuCalculator
    {
        decimal TotalAlphaAcidUnits { get; set; }

        decimal OriginalGravity { get; set; }

        IHopUtilizationTable HopUtilizationTable { get; set; }

        int ExpectedIbu { get; set; }

        int Calculate(List<IHop> hops, decimal originalGravity);
    }
}

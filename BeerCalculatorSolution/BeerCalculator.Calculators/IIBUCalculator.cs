using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators
{
    public interface IIbuCalculator
    {
        decimal TotalAlphaAcidUnits { get; set; }

        decimal OriginalGravity { get; set; }

        IHopUtilizationTable HopUtilizationTable { get; set; }

        int Calculate(List<HopTypeDTO> hops, decimal originalGravity);
    }
}

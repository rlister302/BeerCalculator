using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators.Interface
{
    public interface IGrain
    {
        int MaximumSugarExtraction { get; set; }
        int MaximumExtractionRate { get; set; }

        decimal Amount { get; set; }

        decimal Lovibond { get; set; }
    }
}

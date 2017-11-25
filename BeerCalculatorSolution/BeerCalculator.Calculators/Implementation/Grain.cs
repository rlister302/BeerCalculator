using BeerCalculator.Calculators.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators.Implementation
{
    public class Grain : IGrain
    {
        public int MaximumSugarExtraction { get; set; }
        public int MaximumExtractionRate { get; set; }
        public decimal Amount { get; set; }
        public decimal Lovibond { get; set; }
    }
}

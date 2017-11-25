using BeerCalculator.Calculators.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators.Implementation
{
    public class Hop : IHop
    {
        public decimal Amount { get; set; }
        public decimal AlphaAcid { get; set; }
        public int BoilTime { get; set; }
    }
}

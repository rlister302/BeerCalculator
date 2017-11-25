using BeerCalculator.Calculators.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators.Implementation
{
    public class AbvCalculator : IAbvCalculator
    {
        public decimal ExpectedAbv { get; set; }
        public decimal Calculate(decimal originalGravity, decimal finalGravity)
        {
            decimal abv = (originalGravity - finalGravity) * 131.25m;
            ExpectedAbv = decimal.Round(abv, 2);
            return ExpectedAbv;
        }
    }
}

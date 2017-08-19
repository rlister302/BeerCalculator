using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators
{
    public class AbvCalculator : IAbvCalculator
    {
        public decimal Calculate(decimal originalGravity, decimal finalGravity)
        {
            decimal abv = (originalGravity - finalGravity) * 131.25m;
            return decimal.Round(abv, 2);
        }
    }
}

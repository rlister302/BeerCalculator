using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators
{
    public interface IAbvCalculator
    {
        decimal ExpectedAbv { get; set; }
        decimal Calculate(decimal originalGravity, decimal finalGravity);
    }
}

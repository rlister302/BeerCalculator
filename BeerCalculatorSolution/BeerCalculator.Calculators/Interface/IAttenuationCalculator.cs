using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators.Interface
{
    public interface IAttenuationCalculator
    {
        decimal FinalGravity { get; set; }
        decimal Calculate(decimal originalGravity, int expectedAttenuation);
    }
}

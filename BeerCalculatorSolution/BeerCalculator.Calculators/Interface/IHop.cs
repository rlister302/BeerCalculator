using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators.Interface
{
    public interface IHop
    {
        decimal Amount { get; set; }

        decimal AlphaAcid { get; set; }

        int BoilTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Common.Interface
{
    public interface IHopUtilizationTable
    {
        Dictionary<int, Dictionary<string, decimal>> UtilizationTable { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Abstract
{
    public interface IRecipeMetrics
    {
        decimal ExpectedOG { get; set; }

        decimal ExpectedABV { get; set; }

        int ExpectedIBU { get; set; }

        decimal ExpectedFinalGravity { get; set; }
    }
}

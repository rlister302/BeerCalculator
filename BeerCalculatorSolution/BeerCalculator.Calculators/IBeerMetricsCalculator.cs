﻿using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators
{
    public interface IBeerMetricsCalculator
    {
        IGravityCalculator GravityCalculator { get; set; }

        IRecipeMetrics Calculate();
    }
}

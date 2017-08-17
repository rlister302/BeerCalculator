﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators
{
    public interface IAttenuationCalculator
    {
        decimal Calculate(decimal originalGravity, int expectedAttenuation);
    }
}

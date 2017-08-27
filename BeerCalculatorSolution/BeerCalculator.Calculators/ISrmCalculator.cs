﻿using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators
{
    public interface ISrmCalculator
    {
        decimal ExpectedSrm { get; set; }

        decimal ExpectedMcu { get; set; }
        void Calculate(List<GrainTypeDTO> grains, decimal batchSize);
    }
}

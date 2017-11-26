using BeerCalculator.Common.Abstract;
using BeerCalculator.Common.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators.Interface
{
    public interface IRecipeMetrics
    {
        decimal ExpectedOriginalGravity { get; set; }

        decimal ExpectedBoilGravityPoints { get; set; }

        decimal ExpectedAbv { get; set; }

        int ExpectedIbu { get; set; }

        decimal ExpectedFinalGravity { get; set; }

        decimal ExpectedSrm { get; set; }

        IWaterMetrics WaterMetrics { get; set; }
    }
}

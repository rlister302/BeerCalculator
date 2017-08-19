using Common.Abstract;
using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators
{
    public interface IGravityCalculator
    {
        decimal BoilGravityPoints { get; set; }

        decimal OriginalGravity { get; set; }

        double BoilVolume { get; set; }

        double FinalVolume { get; set; }

        void Calculate(List<GrainTypeDTO> grains, int expectedEfficiency, double boilVolume = 6.5, double finalVolume = 5.5);
    }
}

using BeerCalculator.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Common.Interface
{ 
    public interface IGravityCalculator
    {
        decimal BoilGravityPoints { get; set; }

        decimal OriginalGravity { get; set; }

        decimal BoilVolume { get; set; }

        decimal FinalVolume { get; set; }

        void Calculate(List<GrainTypeDTO> grains, int expectedEfficiency, decimal boilVolume = 6.5m, decimal finalVolume = 5.5m);
    }
}

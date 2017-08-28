using BeerCalculator.Common.Abstract;
using BeerCalculator.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators.Implementation
{
    public class WaterInput : IWaterInput
    {
        public decimal BoilRate { get; set; }

        public decimal EquipmentDeadSpace { get; set; }

        public decimal GrainAbsorbtion { get; set; }

        public decimal MashTemperature { get; set; }

        public decimal MashThickness { get; set; }

        public decimal TrubLoss { get; set; }

        public decimal InitialGrainTemperature { get; set; }
    }
}

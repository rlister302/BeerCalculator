using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators.Interface
{
    public interface IWaterInput
    {
        decimal BoilRate { get; set; }

        decimal EquipmentDeadSpace { get; set; }

        decimal GrainAbsorbtion { get; set; }

        decimal MashTemperature { get; set; }

        decimal MashThickness { get; set; }

        decimal TrubLoss { get; set; }

        decimal InitialGrainTemperature { get; set; }

        decimal DesiredBatchSize { get; set; }

    }
}

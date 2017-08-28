using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Common.Interface
{
    public interface IWaterInput
    {
        decimal BoilRate { get; set; }

        decimal GrainAbsorbtion { get; set; }

        decimal EquipmentDeadSpace { get; set; }

        decimal TrubLoss { get; set; }

        decimal MashThickness { get; set; }

        decimal MashTemperature { get; set; }

        decimal InitialGrainTemperature { get; set; }

        decimal DesiredBatchSize { get; set; }
    }
}

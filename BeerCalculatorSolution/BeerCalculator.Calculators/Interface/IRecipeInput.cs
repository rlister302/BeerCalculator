using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators.Interface
{
    public interface IRecipeInput
    {
        List<IGrain> Grains { get; set; }

        List<IHop> Hops { get; set; }

        int MashEfficiency { get; set; }

        IWaterInput WaterInput { get; set; }

        IYeast Yeast { get; set; }

        int ExpectedAttenuation { get; set; }
    }
}

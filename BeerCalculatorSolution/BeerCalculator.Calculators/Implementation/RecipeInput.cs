using BeerCalculator.Calculators.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Calculators.Implementation
{
    public class RecipeInput : IRecipeInput
    {
        public List<IGrain> Grains { get; set; }
        public List<IHop> Hops { get; set; }
        public int MashEfficiency { get; set; }
        public IWaterInput WaterInput { get; set; }
        public IYeast Yeast { get; set; }
        public int ExpectedAttenuation { get; set; }
    }
}

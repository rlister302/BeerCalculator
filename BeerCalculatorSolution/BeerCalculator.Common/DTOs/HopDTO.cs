using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerCalculator.Common.Abstract;

namespace BeerCalculator.Common.DTOs
{
    public class HopDTO : ModelBase
    {
        public int HopID { get; set; }
        public int HopTypeID { get; set; }
        public int RecipeID { get; set; }
        public double AlphaAcid { get; set; }
    }
}

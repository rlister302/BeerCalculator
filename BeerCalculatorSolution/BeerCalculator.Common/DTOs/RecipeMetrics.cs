using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class RecipeMetrics : IRecipeMetrics
    {
        public decimal ExpectedABV { get; set; }

        public int ExpectedIBU { get; set; }

        public decimal ExpectedOG { get; set; }
    }
}

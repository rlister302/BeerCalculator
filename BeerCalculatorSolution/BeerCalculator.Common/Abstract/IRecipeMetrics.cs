using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Abstract
{
    public interface IRecipeMetrics
    {
        decimal ExpectedOriginalGravity { get; set; }

        decimal ExpectedBoilGravityPoints { get; set; }

        decimal ExpectedAbv { get; set; }

        int ExpectedIbu { get; set; }

        decimal ExpectedFinalGravity { get; set; }
    }
}

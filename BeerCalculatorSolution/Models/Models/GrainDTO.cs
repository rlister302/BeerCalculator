using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class GrainDTO : BaseDTO
    {
        public int GrainID { get; set; }
        public int GrainTypeID { get; set; }
        public int RecipeID { get; set; }
        public double Amount { get; set; }
    }
}

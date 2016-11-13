using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class HopDTO : BaseDTO
    {
        public int HopID { get; set; }
        public int HopTypeID { get; set; }
        public int RecipeID { get; set; }
        public double AlphaAcid { get; set; }
    }
}

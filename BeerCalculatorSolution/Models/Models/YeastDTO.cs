using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class YeastDTO : BaseDTO
    {
        public int YeastID { get; set; }
        public int YeastTypeID { get; set; }
        public int RecipeID { get; set; }
    }
}

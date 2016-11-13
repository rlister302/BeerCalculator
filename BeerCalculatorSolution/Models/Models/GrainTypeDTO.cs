using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class GrainTypeDTO : BaseDTO
    {
        public int GrainTypeID { get; set; }
        public string GrainName { get; set; }
        public int MaximumSugarExtraction { get; set; }
    }
}

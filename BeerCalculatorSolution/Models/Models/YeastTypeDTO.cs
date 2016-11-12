using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class YeastTypeDTO
    {
        public int YeastTypeID { get; set; }
        public string YeastName { get; set; }
        public int LowAttenuationRate { get; set; }
        public int HighAttenuationRate { get; set; }
        public int LowTemperatureRange { get; set; }
        public int HighTemperatureRange { get; set; }

    }
}

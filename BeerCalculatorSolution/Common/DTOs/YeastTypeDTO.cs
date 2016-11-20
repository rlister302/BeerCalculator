using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstract;

namespace Common.DTOs
{
<<<<<<< HEAD:BeerCalculatorSolution/Common/DTOs/YeastTypeDTO.cs
    public class YeastTypeDTO : ModelBase
=======
    public class YeastTypeDTO
>>>>>>> 4d4d2b14b50f429e520bea005f5107de2f1c95da:BeerCalculatorSolution/Models/Models/YeastTypeDTO.cs
    {
        public int YeastTypeID { get; set; }
        public string YeastName { get; set; }
        public int LowAttenuationRate { get; set; }
        public int HighAttenuationRate { get; set; }
        public int LowTemperatureRange { get; set; }
        public int HighTemperatureRange { get; set; }

    }
}

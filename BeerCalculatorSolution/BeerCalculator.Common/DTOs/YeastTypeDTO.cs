using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerCalculator.Common.Abstract;

namespace BeerCalculator.Common.DTOs
{
    [Controller("YeastType")]
    [GetAllAction("GetAllYeastTypes")]
    [GetDetailsAction("GetYeastTypeDetails")]
    [CreateAction("CreateYeastType")]
    [UpdateAction("UpdateYeastType")]
    [DeleteAction("DeleteYeastType")]
    public class YeastTypeDTO : ModelBase
    {
        [PrimaryKey]
        public int YeastTypeID { get; set; }
        public int YeastID { get; set; }
        public int? RecipeID { get; set; }
        public string YeastName { get; set; }
        public int LowAttenuationRate { get; set; }
        public int HighAttenuationRate { get; set; }
        public int LowTemperatureRange { get; set; }
        public int HighTemperatureRange { get; set; }
        public string YeastDescription { get; set; }

    }
}

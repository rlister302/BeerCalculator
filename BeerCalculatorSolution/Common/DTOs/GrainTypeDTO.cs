using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstract;

namespace Common.DTOs
{
    [Controller("GrainType")]
    [GetAllAction("GetAllGrainTypes")]
    [GetDetailsAction("GetGrainTypeDetails")]
    [CreateAction("CreateGrainType")]
    [UpdateAction("UpdateGrainType")]
    [DeleteAction("DeleteGrainType")]
    public class GrainTypeDTO : ModelBase
    {
        [PrimaryKey]
        public int GrainTypeID { get; set; }
        public int GrainID { get; set; }
        public string GrainName { get; set; }
        public int MaximumSugarExtraction { get; set; }
        public int RecipeID { get; set; }
        public double Amount { get; set; }
    }
}

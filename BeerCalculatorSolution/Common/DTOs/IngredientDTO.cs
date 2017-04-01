using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTOs;

namespace Common.DTOs
{
    public class IngredientDTO
    {
        public List<HopTypeDTO> HopTypes { get; set; }
        public List<GrainTypeDTO> GrainTypes { get; set; }
        public List<YeastTypeDTO> YeastTypes { get; set; }
    }
}

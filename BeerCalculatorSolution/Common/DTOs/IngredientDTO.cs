﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTOs;
using Common.Abstract;

namespace Common.DTOs
{
    [Controller("Ingredient")]
    [GetAllAction("GetAllIngredients")]
    public class IngredientDTO : ModelBase
    {
        public List<HopTypeDTO> HopTypes { get; set; }
        public List<GrainTypeDTO> GrainTypes { get; set; }
        public List<YeastTypeDTO> YeastTypes { get; set; }
    }
}

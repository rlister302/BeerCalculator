﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstract;

namespace Common.DTOs
{
    [Controller("HopType")]
    [GetAllAction("GetAllHopTypes")]
    [GetDetailsAction("GetHopTypeDetails")]
    [CreateAction("CreateHopType")]
    [UpdateAction("UpdateHopType")]
    [DeleteAction("DeleteHopType")]
    public class HopTypeDTO : ModelBase
    {
        [PrimaryKey]
        public int HopTypeID { get; set; }
        public string HopName { get; set; }
        public string FlavorNotes { get; set; }
    }
}
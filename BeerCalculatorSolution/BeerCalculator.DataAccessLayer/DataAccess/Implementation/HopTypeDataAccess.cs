using BeerCalculator.Common.DTOs;
using BeerCalculator.DataAccessLayer.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.DataAccessLayer.DataAccess.Implementation
{
    public class HopTypeDataAccess : AbstractDataAccess<HopTypeDTO, HopType>
    {
        protected override HopType ConvertDTOToEntity(HopTypeDTO dto)
        {
            HopType entity = new HopType();
            entity.HopTypeID = dto.HopTypeID;
            entity.FlavorNotes = dto.FlavorNotes;
            entity.HopName = dto.HopName;
            return entity;
        }

        protected override HopTypeDTO ConvertEntityToDTO(HopType entity)
        {
            HopTypeDTO hopType = new HopTypeDTO();
            hopType.HopTypeID = entity.HopTypeID;
            hopType.HopName = entity.HopName;
            hopType.FlavorNotes = entity.FlavorNotes;
            return hopType;
        }

        protected override void SetEntityProperties(HopTypeDTO dto, HopType entity)
        {
            entity.HopTypeID = dto.HopTypeID;
            entity.FlavorNotes = dto.FlavorNotes;
            entity.HopName = dto.HopName;
        }
    }
}

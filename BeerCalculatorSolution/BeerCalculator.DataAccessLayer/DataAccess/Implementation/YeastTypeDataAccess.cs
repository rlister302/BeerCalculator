using BeerCalculator.Common.DTOs;
using BeerCalculator.DataAccessLayer.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.DataAccessLayer.DataAccess.Implementation
{
    public class YeastTypeDataAccess : AbstractDataAccess<YeastTypeDTO, YeastType>
    {
        protected override YeastType ConvertDTOToEntity(YeastTypeDTO dto)
        {
            YeastType yeastEntity = new YeastType();
            yeastEntity.YeastTypeID = dto.YeastTypeID;
            yeastEntity.YeastName = dto.YeastName;
            yeastEntity.LowAttenuationRate = dto.LowAttenuationRate;
            yeastEntity.HighAttenuationRate = dto.HighAttenuationRate;
            yeastEntity.LowTemperatureRange = dto.LowTemperatureRange;
            yeastEntity.HighTemperatureRange = dto.HighTemperatureRange;
            yeastEntity.Description = dto.YeastDescription;
            return yeastEntity;
        }

        protected override YeastTypeDTO ConvertEntityToDTO(YeastType entity)
        {
            var yeastTypeDTO = new YeastTypeDTO();

            yeastTypeDTO.YeastTypeID = entity.YeastTypeID;
            yeastTypeDTO.YeastName = entity.YeastName;
            yeastTypeDTO.LowAttenuationRate = (int)entity.LowAttenuationRate;
            yeastTypeDTO.HighAttenuationRate = (int)entity.HighAttenuationRate;
            yeastTypeDTO.LowTemperatureRange = (int)entity.LowTemperatureRange;
            yeastTypeDTO.HighTemperatureRange = (int)entity.HighTemperatureRange;
            yeastTypeDTO.YeastDescription = entity.Description;
            return yeastTypeDTO;
        }

        protected override void SetEntityProperties(YeastTypeDTO dto, YeastType entity)
        {
            entity.YeastTypeID = dto.YeastTypeID;
            entity.YeastName = dto.YeastName;
            entity.LowAttenuationRate = dto.LowAttenuationRate;
            entity.HighAttenuationRate = dto.HighAttenuationRate;
            entity.LowTemperatureRange = dto.LowTemperatureRange;
            entity.HighTemperatureRange = dto.HighTemperatureRange;
            entity.Description = dto.YeastDescription;
        }
    }
}

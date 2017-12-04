using BeerCalculator.Common.DTOs;
using BeerCalculator.DataAccessLayer.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.DataAccessLayer.DataAccess.Implementation
{
    public class GrainTypeDataAccess : AbstractDataAccess<GrainTypeDTO, GrainType>
    {
        protected override GrainType ConvertDTOToEntity(GrainTypeDTO dto)
        {
            GrainType entity = new GrainType();
            entity.GrainTypeID = dto.GrainTypeID;
            entity.MaximumSugarExtraction = dto.MaximumSugarExtraction;
            entity.MaximumExtractionRate = dto.MaximumExtractionRate;
            entity.Lovibond = dto.Lovibond;
            entity.GrainName = dto.GrainName;
            return entity;
        }

        protected override GrainTypeDTO ConvertEntityToDTO(GrainType entity)
        {
            GrainTypeDTO grainDTO = new GrainTypeDTO();
            grainDTO.GrainTypeID = entity.GrainTypeID;
            grainDTO.MaximumSugarExtraction = (int)entity.MaximumSugarExtraction;
            grainDTO.MaximumExtractionRate = entity.MaximumExtractionRate;
            grainDTO.GrainName = entity.GrainName;
            grainDTO.Lovibond = entity.Lovibond;
            return grainDTO;
        }

        protected override void SetEntityProperties(GrainTypeDTO dto, GrainType entity)
        {
            entity.GrainTypeID = dto.GrainTypeID;
            entity.MaximumSugarExtraction = dto.MaximumSugarExtraction;
            entity.MaximumExtractionRate = dto.MaximumExtractionRate;
            entity.Lovibond = dto.Lovibond;
            entity.GrainName = dto.GrainName;
        }
    }
}

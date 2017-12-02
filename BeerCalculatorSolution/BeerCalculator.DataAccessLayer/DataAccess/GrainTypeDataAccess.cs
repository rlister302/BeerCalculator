using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataAccess.Interface;
using BeerCalculator.DataAccessLayer;
using BeerCalculator.Common.DTOs;

namespace BeerCalculator.DataAccessLayer.DataAccess
{
    public class GrainTypeDataAccess : IDataAccess<GrainTypeDTO>
    {
        public bool Create(GrainTypeDTO create)
        {
            bool status = false;

            using (var context = new BeerCalculatorEntities())
            {
                var entity = new GrainType();
                entity.GrainName = create.GrainName;
                entity.MaximumSugarExtraction = create.MaximumSugarExtraction;
                entity.MaximumExtractionRate = create.MaximumExtractionRate;
                entity.Lovibond = create.Lovibond;
                context.GrainTypes.Add(entity);
                context.SaveChanges();
                status = true;
            }

            return status;
        }

        public bool Delete(int delete)
        {
            bool status = false;

            using (var context = new BeerCalculatorEntities())
            {
                var entity = context.GrainTypes.Find(delete);
                context.GrainTypes.Remove(entity);
                context.SaveChanges();
                status = true;
            }

            return status;
        }

        public IEnumerable<GrainTypeDTO> Get()
        {
            var grainTypes = new List<GrainTypeDTO>();

            using (var context = new BeerCalculatorEntities())
            {
                foreach (var grainEntity in context.GrainTypes)
                {
                    grainTypes.Add(ConvertEntityToDTO(grainEntity));
                }
            }

            return grainTypes;
        }

        private GrainTypeDTO ConvertEntityToDTO(GrainType entity)
        {
            GrainTypeDTO grainDTO = new GrainTypeDTO();
            grainDTO.GrainTypeID = entity.GrainTypeID;
            grainDTO.MaximumSugarExtraction = (int)entity.MaximumSugarExtraction;
            grainDTO.MaximumExtractionRate = entity.MaximumExtractionRate;
            grainDTO.GrainName = entity.GrainName;
            grainDTO.Lovibond = entity.Lovibond;
            return grainDTO;
        }

        public GrainTypeDTO Get(int id)
        {
            GrainTypeDTO grainDTO = null;

            using (var context = new BeerCalculatorEntities())
            {
                var grainEntity = context.GrainTypes.Find(id);

                if (grainEntity != null)
                {
                    grainDTO = ConvertEntityToDTO(grainEntity);
                }
            }

            return grainDTO;
        }

        public bool Update(GrainTypeDTO update)
        {
            bool status = false;

            using (var context = new BeerCalculatorEntities())
            {
                var entity = context.GrainTypes.Find(update.GrainTypeID);

                if (entity != null)
                {
                    entity.GrainName = update.GrainName;
                    entity.MaximumSugarExtraction = update.MaximumSugarExtraction;
                    entity.MaximumExtractionRate = update.MaximumExtractionRate;
                    entity.Lovibond = update.Lovibond;
                    context.SaveChanges();
                    status = true;
                }
            }

            return status;
        }
    }
}

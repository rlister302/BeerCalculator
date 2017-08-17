using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTOs;
using Common.Abstract;
using DataAccessLayer.DataAccess.Interface;
using BeerCalculator.DataAccessLayer;

namespace DataAccessLayer.DataAccess
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
                    var grainType = new GrainTypeDTO();
                    grainType.GrainTypeID = grainEntity.GrainTypeID;
                    grainType.GrainName = grainEntity.GrainName;
                    grainType.MaximumSugarExtraction = (int)grainEntity.MaximumSugarExtraction;
                    grainTypes.Add(grainType);
                }
            }

            return grainTypes;
        }

        public GrainTypeDTO Get(GrainTypeDTO details)
        {
            var grainDTO = new GrainTypeDTO();

            using (var context = new BeerCalculatorEntities())
            {
                var grainEntity = context.GrainTypes.Find(details.GrainTypeID);

                if (grainEntity != null)
                {
                    grainDTO.GrainTypeID = grainEntity.GrainTypeID;
                    grainDTO.MaximumSugarExtraction = (int)grainEntity.MaximumSugarExtraction;
                    grainDTO.GrainName = grainEntity.GrainName;
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
                    context.SaveChanges();
                    status = true;
                }
            }

            return status;
        }
    }
}

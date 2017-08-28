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
    public class YeastTypeDataAccess : IDataAccess<YeastTypeDTO>
    {
        public bool Create(YeastTypeDTO create)
        {
            bool status = false;

            using (var context = new BeerCalculatorEntities())
            {
                var entity = new YeastType();
                entity.YeastName = create.YeastName;
                entity.HighAttenuationRate = create.HighAttenuationRate;
                entity.LowAttenuationRate = create.LowAttenuationRate;
                entity.LowTemperatureRange = create.LowTemperatureRange;
                entity.HighTemperatureRange = create.HighTemperatureRange;
                entity.Description = create.YeastDescription;
                context.YeastTypes.Add(entity);
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
                var entity = context.YeastTypes.Find(delete);

                if (entity != null)
                {
                    context.YeastTypes.Remove(entity);
                    context.SaveChanges();
                    status = true;
                }
            }

            return status;
        }

        public IEnumerable<YeastTypeDTO> Get()
        {
            var yeastTypes = new List<YeastTypeDTO>();

            using (var context = new BeerCalculatorEntities())
            {
                foreach (var yeastEntity in context.YeastTypes)
                {
                    var yeastTypeDTO = new YeastTypeDTO();

                    yeastTypeDTO.YeastTypeID = yeastEntity.YeastTypeID;
                    yeastTypeDTO.YeastName = yeastEntity.YeastName;
                    yeastTypeDTO.LowAttenuationRate = (int)yeastEntity.LowAttenuationRate;
                    yeastTypeDTO.HighAttenuationRate = (int)yeastEntity.HighAttenuationRate;
                    yeastTypeDTO.LowTemperatureRange = (int)yeastEntity.LowTemperatureRange;
                    yeastTypeDTO.HighTemperatureRange = (int)yeastEntity.HighTemperatureRange;

                    yeastTypes.Add(yeastTypeDTO);
                }
            }

            return yeastTypes;
        }

        public YeastTypeDTO Get(YeastTypeDTO details)
        {
            var yeastTypeDTO = new YeastTypeDTO();

            using (var context = new BeerCalculatorEntities())
            {
                var yeastEntity = context.YeastTypes.Find(details.YeastTypeID);

                yeastTypeDTO.YeastTypeID = yeastEntity.YeastTypeID;
                yeastTypeDTO.YeastName = yeastEntity.YeastName;
                yeastTypeDTO.LowAttenuationRate = (int)yeastEntity.LowAttenuationRate;
                yeastTypeDTO.HighAttenuationRate = (int)yeastEntity.HighAttenuationRate;
                yeastTypeDTO.LowTemperatureRange = (int)yeastEntity.LowTemperatureRange;
                yeastTypeDTO.HighTemperatureRange = (int)yeastEntity.HighTemperatureRange;
            }

            return yeastTypeDTO;
        }

        public bool Update(YeastTypeDTO update)
        {
            bool status = false;

            using (var context = new BeerCalculatorEntities())
            {
                var yeastEntity = context.YeastTypes.Find(update.YeastTypeID);

                if (yeastEntity != null)
                {
                    yeastEntity.YeastTypeID = update.YeastTypeID;
                    yeastEntity.YeastName = yeastEntity.YeastName;
                    yeastEntity.LowAttenuationRate = update.LowAttenuationRate;
                    yeastEntity.HighAttenuationRate = update.HighAttenuationRate;
                    yeastEntity.LowTemperatureRange = update.LowTemperatureRange;
                    yeastEntity.HighTemperatureRange = update.HighTemperatureRange;
                }
            }

            return status;
        }
    }
}

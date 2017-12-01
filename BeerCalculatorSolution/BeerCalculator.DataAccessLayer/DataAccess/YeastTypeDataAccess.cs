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

                UpdateYeastEntityProperties(entity, create);
                entity.YeastTypeID = 0;
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
                    YeastTypeDTO yeastTypeDTO = ConvertYeastEntityToDTO(yeastEntity);
                    yeastTypes.Add(yeastTypeDTO);
                }
            }

            return yeastTypes;
        }

        public YeastTypeDTO Get(int id)
        {
            var yeastTypeDTO = new YeastTypeDTO();

            using (var context = new BeerCalculatorEntities())
            {
                var yeastEntity = context.YeastTypes.Find(id);
                yeastTypeDTO = ConvertYeastEntityToDTO(yeastEntity);
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
                    UpdateYeastEntityProperties(yeastEntity, update);
                    context.SaveChanges();
                    status = true;
                }
            }

            return status;
        }

        #region Private Methods
        private YeastTypeDTO ConvertYeastEntityToDTO(YeastType yeastEntity)
        {
            var yeastTypeDTO = new YeastTypeDTO();

            yeastTypeDTO.YeastTypeID = yeastEntity.YeastTypeID;
            yeastTypeDTO.YeastName = yeastEntity.YeastName;
            yeastTypeDTO.LowAttenuationRate = (int)yeastEntity.LowAttenuationRate;
            yeastTypeDTO.HighAttenuationRate = (int)yeastEntity.HighAttenuationRate;
            yeastTypeDTO.LowTemperatureRange = (int)yeastEntity.LowTemperatureRange;
            yeastTypeDTO.HighTemperatureRange = (int)yeastEntity.HighTemperatureRange;
            yeastTypeDTO.YeastDescription = yeastEntity.Description;
            return yeastTypeDTO;
        }

        private void UpdateYeastEntityProperties(YeastType yeastEntity, YeastTypeDTO yeastType)
        {
            yeastEntity.YeastTypeID = yeastType.YeastTypeID;
            yeastEntity.YeastName = yeastType.YeastName;
            yeastEntity.LowAttenuationRate = yeastType.LowAttenuationRate;
            yeastEntity.HighAttenuationRate = yeastType.HighAttenuationRate;
            yeastEntity.LowTemperatureRange = yeastType.LowTemperatureRange;
            yeastEntity.HighTemperatureRange = yeastType.HighTemperatureRange;
            yeastEntity.Description = yeastType.YeastDescription;
        }
        #endregion
    }
}

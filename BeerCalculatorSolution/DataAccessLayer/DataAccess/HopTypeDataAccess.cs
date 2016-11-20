using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.DTOs;
using DataAccessLayer;

namespace DataAccessLayer.DataAccess
{
    public class HopTypeDataAccess
    {
        public bool CreateHopType(HopTypeDTO create)
        {
            bool status = false;
            using (var context = new BeerCalculatorEntities())
            {
                var entity = new HopType();
                entity.FlavorNotes = create.FlavorNotes;
                entity.HopName = create.HopName;
                context.HopTypes.Add(entity);
                context.SaveChanges();
                status = true;
            }

            return status;
        }

        public List<HopTypeDTO> GetAllHopTypes()
        {
            var hopTypes = new List<HopTypeDTO>();
            using (var context = new BeerCalculatorEntities())
            {
                var hopTypeEntities = context.HopTypes.ToList();
                foreach(var entity in hopTypeEntities)
                {
                    var dto = new HopTypeDTO();
                    dto.HopTypeID = entity.HopTypeID;
                    dto.HopName = entity.HopName;
                    dto.FlavorNotes = entity.FlavorNotes;
                    hopTypes.Add(dto);
                }
            }

            return hopTypes;
        }

        public HopTypeDTO GetHopTypeDetails(HopTypeDTO details)
        {
            var hopType = new HopTypeDTO();
            using (var context = new BeerCalculatorEntities())
            {
                var entity = context.HopTypes.Find(details.HopTypeID);
                if(entity != null)
                {
                    hopType.HopTypeID = entity.HopTypeID;
                    hopType.HopName = entity.HopName;
                    hopType.FlavorNotes = entity.FlavorNotes;
                }
            }

            return hopType;
        }

        public bool UpdateHopType(HopTypeDTO update)
        {
            bool status = false;
            using (var context = new BeerCalculatorEntities())
            {
                var entity = context.HopTypes.Find(update.HopTypeID);
                entity.HopName = update.HopName;
                entity.FlavorNotes = update.FlavorNotes;
                context.SaveChanges();
                status = true;
            }

            return status;
        }

        public bool DeleteHopType(HopTypeDTO delete)
        {
            bool status = false;

            using (var context = new BeerCalculatorEntities())
            {
                var entity = context.HopTypes.Find(delete.HopTypeID);
                context.HopTypes.Remove(entity);
                context.SaveChanges();
                status = true;
            }

            return status;
        }
    }
}
using BeerCalculator.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerCalculator.Common.DTOs;

namespace BeerCalculator.DataAccessLayer.DataAccess
{
    public class RecipeMetaDataResolver : IRecipeMetaDataResolver
    {
        public bool ResolveGrainMetaData(List<GrainTypeDTO> grains)
        {
            bool success = false;

            using (var context = new BeerCalculatorEntities())
            {
                foreach (GrainTypeDTO grain in grains)
                {
                    GrainType entity = context.GrainTypes.Find(grain.GrainTypeID);
                    grain.MaximumExtractionRate = entity.MaximumExtractionRate;
                    grain.Lovibond = entity.Lovibond;
                    grain.MaximumSugarExtraction = entity.MaximumSugarExtraction;
                }
            }
            success = true;

            return success;
        }

        public bool ResolveHopMetaData(List<HopTypeDTO> hops)
        {
            bool success = false;

            using (var context = new BeerCalculatorEntities())
            {
                foreach (HopTypeDTO hop in hops)
                {
                    HopType entity = context.HopTypes.Find(hop.HopTypeID);
   
                }
            }

            success = true;

            return success;
        }

        public bool ResolveYeastMetaData(YeastTypeDTO yeast)
        {
            bool success = false;

            using (var context = new BeerCalculatorEntities())
            {
                YeastType entity = context.YeastTypes.Find(yeast.YeastTypeID);
                yeast.LowAttenuationRate = entity.LowAttenuationRate;
                yeast.HighAttenuationRate = entity.HighAttenuationRate;
                yeast.LowTemperatureRange = entity.LowTemperatureRange;
                yeast.HighTemperatureRange = entity.HighTemperatureRange;
            }
            success = true;
            return success;
        }
    }
}

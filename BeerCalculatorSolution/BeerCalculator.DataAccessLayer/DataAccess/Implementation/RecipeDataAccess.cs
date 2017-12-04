using BeerCalculator.Common.DTOs;
using BeerCalculator.DataAccessLayer.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.DataAccessLayer.DataAccess.Implementation
{
    public class RecipeDataAccess : AbstractDataAccess<RecipeDTO, Recipe>
    {
        protected override Recipe ConvertDTOToEntity(RecipeDTO dto)
        {
            var recipeEntity = new Recipe();

            recipeEntity.RecipeName = dto.RecipeName;
            recipeEntity.ExpectedABV = dto.ExpectedABV;
            recipeEntity.ExpectedOriginalGravity = dto.ExpectedOriginalGravity;
            recipeEntity.ExpectedFinalGravity = dto.ExpectedFinalGravity;
            recipeEntity.ExpectedMashEfficiency = dto.ExpectedMashEfficiency;
            recipeEntity.IBU = dto.IBU;
            recipeEntity.BoilVolume = dto.WaterMetrics.BoilVolume;
            recipeEntity.FinalVolume = dto.FinalVolume;
            recipeEntity.BoilRate = dto.WaterInput.BoilRate;
            recipeEntity.EquipmentDeadSpace = dto.WaterInput.EquipmentDeadSpace;
            recipeEntity.GrainAbsorbtion = dto.WaterInput.GrainAbsorbtion;
            recipeEntity.MashTemperature = (int)dto.WaterInput.MashTemperature;
            recipeEntity.MashThickness = dto.WaterInput.MashThickness;
            recipeEntity.TrubLoss = dto.WaterInput.TrubLoss;
            recipeEntity.InitialGrainTemperature = dto.WaterInput.InitialGrainTemperature;
            recipeEntity.WaterRequired = (int)dto.WaterMetrics.WaterRequired;
            recipeEntity.StrikeTemperature = dto.WaterMetrics.StrikeTemperature;
            recipeEntity.StrikeVolume = dto.WaterMetrics.StrikeVolume;
            recipeEntity.SpargeVolume = dto.WaterMetrics.SpargeVolume;
            recipeEntity.SpargeTemperature = 170;
            recipeEntity.ExpectedBoilGravityPoints = dto.ExpectedBoilGravityPoints;
            recipeEntity.Grains = ConvertGrainDTOToEntity(dto.Grains);
            recipeEntity.Hops = ConvertHopDTOToEntity(dto.Hops);
            recipeEntity.Yeasts = ConvertYeastDTOToEntity(dto.Yeast);

            return recipeEntity;
        }

        private ICollection<Grain> ConvertGrainDTOToEntity(IEnumerable<GrainTypeDTO> recipeGrains)
        {
            List<Grain> grainEntities = new List<Grain>();

            foreach (var grain in recipeGrains)
            {
                var entity = new Grain();
                entity.GrainTypeID = grain.GrainTypeID;
                entity.Amount = grain.Amount;

                grainEntities.Add(entity);
            }

            return grainEntities;
        }

        private ICollection<Hop> ConvertHopDTOToEntity(IEnumerable<HopTypeDTO> recipeHops)
        {
            List<Hop> hopEntities = new List<Hop>();

            foreach (var hop in recipeHops)
            {
                var entity = new Hop();
                entity.AlphaAcid = hop.AlphaAcid;
                entity.Amount = hop.Amount;
                entity.BoilTime = hop.BoilTime;
                entity.HopTypeID = hop.HopTypeID;
                hopEntities.Add(entity);
            }

            return hopEntities;
        }

        private ICollection<Yeast> ConvertYeastDTOToEntity(YeastTypeDTO yeast)
        {
            List<Yeast> yeasts = new List<Yeast>();
            var yeastEntity = new Yeast();
            yeastEntity.YeastTypeID = yeast.YeastTypeID;
            yeasts.Add(yeastEntity);
            return yeasts;
        }

        protected override RecipeDTO ConvertEntityToDTO(Recipe entity)
        {
            throw new NotImplementedException();
        }

        protected override void SetEntityProperties(RecipeDTO dto, Recipe entity)
        {
            throw new NotImplementedException();
        }
    }
}

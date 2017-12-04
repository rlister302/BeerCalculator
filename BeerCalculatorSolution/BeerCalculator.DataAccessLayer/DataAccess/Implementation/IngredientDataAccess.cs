using BeerCalculator.Common.DTOs;
using BeerCalculator.DataAccessLayer.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.DataAccessLayer.DataAccess.Implementation
{
    public class IngredientDataAccess : AbstractDataAccess<IngredientDTO, Recipe>
    {
        protected override Recipe ConvertDTOToEntity(IngredientDTO dto)
        {
            throw new NotImplementedException();
        }

        protected override IngredientDTO ConvertEntityToDTO(Recipe entity)
        {
            throw new NotImplementedException();
        }

        protected override void SetEntityProperties(IngredientDTO dto, Recipe entity)
        {
            throw new NotImplementedException();
        }

        public override IngredientDTO Get(int details)
        {
            var grains = new GrainTypeDataAccess().Get();

            var hops = new HopTypeDataAccess().Get();

            var yeast = new YeastTypeDataAccess().Get();

            var ingredientDTO = new IngredientDTO();

            ingredientDTO.GrainTypes = grains.ToList();

            ingredientDTO.HopTypes = hops.ToList();

            ingredientDTO.YeastTypes = yeast.ToList();

            return ingredientDTO;
        }
    }
}

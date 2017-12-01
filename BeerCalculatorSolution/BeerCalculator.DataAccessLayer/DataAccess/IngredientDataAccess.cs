﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataAccess.Interface;
using DataAccessLayer.DataAccess;
using BeerCalculator.Common.DTOs;

namespace BeerCalculator.DataAccessLayer.DataAccess
{
    public class IngredientDataAccess : IDataAccess<IngredientDTO>
    {
        public bool Create(IngredientDTO create)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int delete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IngredientDTO> Get()
        {
            throw new NotImplementedException();
        }

        public IngredientDTO Get(int id)
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

        public bool Update(IngredientDTO update)
        {
            throw new NotImplementedException();
        }
    }
}

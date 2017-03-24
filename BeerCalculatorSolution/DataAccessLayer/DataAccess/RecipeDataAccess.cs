using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataAccess.Interface;
using Common.DTOs;


namespace DataAccessLayer.DataAccess
{
    public class RecipeDataAccess : IDataAccess<RecipeDTO>
    {
        public bool Create(RecipeDTO create)
        {
            bool status = false;

            return status;
        }

        public bool Delete(int delete)
        {
            bool status = false;

            using (var context = new BeerCalculatorEntities())
            {
                var recipe = context.Recipes.Find(delete);

                if (recipe != null)
                {
                    context.Recipes.Remove(recipe);
                    context.SaveChanges();
                    status = true;
                }
            }

            return status;
        }

        public IEnumerable<RecipeDTO> Get()
        {
            IEnumerable<RecipeDTO> recipes = new List<RecipeDTO>();

            using (var context = new BeerCalculatorEntities())
            {
                foreach(var recipe in context.Recipes)
                {
                    var recipeDTO = new RecipeDTO();

                    recipeDTO.RecipeID = recipe.RecipeID;
                    recipe.ExpectedABV = recipe.ExpectedABV;
                    recipe.ExpectedOG = recipe.ExpectedOG;
                    recipe.ExpectedFG = recipe.ExpectedFG;
                    recipe.IBU = recipe.IBU;

                    List<HopTypeDTO> hops = context.Hops.
                        Join(context.HopTypes,
                        hop => hop.BrewProcessID,
                        hopType => hopType.HopTypeID,
                        (hop, hopType) => new HopTypeDTO { HopName = hopType.HopName, FlavorNotes = hopType.FlavorNotes }).ToList();
                }
            }

            return recipes;
        }

        public RecipeDTO Get(RecipeDTO details)
        {
            throw new NotImplementedException();
        }

        public bool Update(RecipeDTO update)
        {
            throw new NotImplementedException();
        }
    }
}

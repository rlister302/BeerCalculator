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

            using (var context = new BeerCalculatorEntities())
            {
                var recipe = ConvertRecipeDTOToEntity(create);
                recipe = context.Recipes.Add(recipe);

                int recipeId = recipe.RecipeID;

                var hops = ConvertHopDTOToEntity(create.Hops, recipeId);
                context.Hops.AddRange(hops);

                var grains = ConvertGrainDTOToEntity(create.Grains, recipeId);
                context.Grains.AddRange(grains);

                var yeast = ConvertYeastDTOToEntity(create.Yeast, recipeId);
                context.Yeasts.Add(yeast);

                status = true;
            }

            return status;
        }

        private Yeast ConvertYeastDTOToEntity(YeastTypeDTO yeast, int recipeId)
        {
            var yeastEntity = new Yeast();

            yeastEntity.RecipeID = recipeId;
            yeastEntity.YeastTypeID = yeast.YeastTypeID;

            return yeastEntity; 
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
            List<RecipeDTO> recipes = new List<RecipeDTO>();

            using (var context = new BeerCalculatorEntities())
            {
                foreach (var recipe in context.Recipes)
                {
                    var recipeDTO = new RecipeDTO();

                    recipeDTO.RecipeID = recipe.RecipeID;
                    recipeDTO.RecipeName = recipe.RecipeName;
                    recipeDTO.ExpectedABV = (double)recipe.ExpectedABV;
                    recipeDTO.ExpectedOG = (double)recipe.ExpectedOG;
                    recipeDTO.ExpectedFG = (double)recipe.ExpectedFG;
                    recipeDTO.IBU = (int)recipe.IBU;

                    recipeDTO.Grains = GetGrainsForRecipe(context, recipeDTO.RecipeID);
                    recipeDTO.Hops = GetHopsForRecipe(context, recipeDTO.RecipeID);
                    recipeDTO.Yeast = GetYeastForRecipe(context, recipeDTO.RecipeID);

                    recipes.Add(recipeDTO);
                }
            }

            return recipes;
        }

        public RecipeDTO Get(RecipeDTO details)
        {
            RecipeDTO recipeDTO = new RecipeDTO();

            using (var context = new BeerCalculatorEntities())
            {
                var recipe = context.Recipes.Where(x => x.RecipeID == details.RecipeID).Single();

                recipeDTO.RecipeID = recipe.RecipeID;
                recipeDTO.RecipeName = recipe.RecipeName;
                recipeDTO.ExpectedABV = (double)recipe.ExpectedABV;
                recipeDTO.ExpectedOG = (double)recipe.ExpectedOG;
                recipeDTO.ExpectedFG = (double)recipe.ExpectedFG;
                recipeDTO.IBU = (int)recipe.IBU;

                recipeDTO.Grains = GetGrainsForRecipe(context, recipe.RecipeID);
                recipeDTO.Hops = GetHopsForRecipe(context, recipe.RecipeID);
                recipeDTO.Yeast = GetYeastForRecipe(context, recipe.RecipeID);

            }

            return recipeDTO;
        }

        public bool Update(RecipeDTO update)
        {
            throw new NotImplementedException();
        }

        #region Private Methods
        private List<GrainTypeDTO> GetGrainsForRecipe(BeerCalculatorEntities context, int recipeID)
        {
            List<GrainTypeDTO> grains = context.Grains.Join(
                        context.Recipes,
                        grain => grain.RecipeID,
                        r => r.RecipeID,
                        (grain, r) => new GrainTypeDTO { GrainTypeID = (int)grain.GrainTypeID, GrainID = grain.GrainID, GrainName = null, Amount = (int)grain.Amount, RecipeID = grain.RecipeID })
                        .Join(context.GrainTypes,
                        grain => grain.GrainTypeID,
                        grainType => grainType.GrainTypeID,
                        (grain, grainType) => new GrainTypeDTO { GrainTypeID = grain.GrainTypeID, GrainID = grain.GrainID, GrainName = grainType.GrainName, Amount = grain.Amount, RecipeID = grain.RecipeID })
                        .Where(x => x.RecipeID == recipeID).ToList();

            return grains;
        }

        private List<HopTypeDTO> GetHopsForRecipe(BeerCalculatorEntities context, int recipeID)
        {
            List<HopTypeDTO> hops = context.Hops.Join(context.Recipes,
                       hop => hop.RecipeID,
                       r => r.RecipeID,
                       (hop, r) => new HopTypeDTO { RecipeID = r.RecipeID, AlphaAcid = hop.AlphaAcid, Amount = hop.Amount, FlavorNotes = null, HopName = null, HopTypeID = (int)hop.HopTypeID, HopID = hop.HopID })
                       .Join(context.HopTypes,
                       hop => hop.HopTypeID,
                       hopType => hopType.HopTypeID,
                       (hop, hopType) => new HopTypeDTO { RecipeID = hop.RecipeID, AlphaAcid = hop.AlphaAcid, Amount = hop.Amount, FlavorNotes = hopType.FlavorNotes, HopName = hopType.HopName, HopTypeID = (int)hopType.HopTypeID, HopID = hop.HopID })
                       .Where(h => h.RecipeID == recipeID).ToList();

            return hops;
        }

        private YeastTypeDTO GetYeastForRecipe(BeerCalculatorEntities context, int recipeID)
        {
            YeastTypeDTO yeast = context.Yeasts.Join(
                        context.Recipes,
                        y => y.RecipeID,
                        r => r.RecipeID,
                        (y, r) => new YeastTypeDTO { YeastTypeID = (int)y.YeastTypeID, YeastID = (int)y.YeastID, YeastName = null, RecipeID = r.RecipeID })
                        .Join(context.YeastTypes,
                        y => y.YeastTypeID,
                        yt => yt.YeastTypeID,
                        (y, yt) => new YeastTypeDTO { YeastTypeID = y.YeastTypeID, YeastID = y.YeastID, YeastName = yt.YeastName, RecipeID = y.RecipeID })
                        .Where(x => x.RecipeID == recipeID)
                        .Single();

            return yeast;
        }

        private Recipe ConvertRecipeDTOToEntity(RecipeDTO recipe)
        {
            var recipeEntity = new Recipe();

            recipeEntity.RecipeName = recipe.RecipeName;

                //TODO: This will eventually be calculated... for now just mock
            //recipeEntity.ExpectedABV = (double)recipe.ExpectedABV;
            //recipeEntity.ExpectedOG = (double)recipe.ExpectedOG;
            //recipeEntity.ExpectedFG = (double)recipe.ExpectedFG;
            recipeEntity.ExpectedABV = 0.000m;
            recipeEntity.ExpectedOG = 0.000m;
            recipeEntity.ExpectedFG = 0.000m;
            recipeEntity.IBU = (int)recipe.IBU;

            return recipeEntity;
        }

        private IEnumerable<Hop> ConvertHopDTOToEntity(IEnumerable<HopTypeDTO> recipeHops, int recipeId)
        {
            List<Hop> hopEntities = new List<Hop>();

            foreach (var hop in recipeHops)
            {
                var entity = new Hop();
                entity.RecipeID = recipeId;
                entity.AlphaAcid = hop.AlphaAcid;
                entity.Amount = hop.Amount;
                entity.TimeAdded = hop.BoilTime;
                entity.HopTypeID = hop.HopTypeID;
                hopEntities.Add(entity);
            }

            return hopEntities;
        }

        private IEnumerable<Grain> ConvertGrainDTOToEntity(IEnumerable<GrainTypeDTO> recipeGrains, int recipeId)
        {
            List<Grain> grainEntities = new List<Grain>();

            foreach (var grain in recipeGrains)
            {
                var entity = new Grain();
                entity.RecipeID = recipeId;
                entity.GrainTypeID = grain.GrainTypeID;
                entity.Amount = grain.Amount;

                grainEntities.Add(entity);
            }

            return grainEntities;
        }
        #endregion Private Methods
    }
}

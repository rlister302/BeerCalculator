using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Models;

namespace BeerCalculatorWebApplication.Controllers
{
    public class RecipeController : Controller
    {
        public ActionResult GetRecipes()
        {
            var recipeList = new List<RecipeDTO>();

            using (var ctx = new DataAccessLayer.BeerCalculatorEntities())
            {
                var result = ctx.Recipes.ToList();
                foreach (var r in result)
                {
                    recipeList.Add(
                        new RecipeDTO
                        {
                            ActualABV = r.ActualABV.HasValue ? r.ActualABV.Value : 0.0,
                            ActualFG = r.ActualFG.HasValue ? r.ActualFG.Value : 0.0,
                            ActualOG = r.ActualOG.HasValue ? r.ActualOG.Value : 0.0,
                            BrewDate = r.BrewDate.HasValue ? r.BrewDate.Value : new DateTime(),
                            IBU = r.IBU.HasValue ? r.IBU.Value : 0,
                            MashEfficiency = r.MashEfficiency.HasValue ? r.MashEfficiency.Value : 0,
                            RecipeID = r.RecipeID,
                            RecipeName = r.RecipeName ?? string.Empty
                        }
                    );
                }
            }
            return Json(recipeList);
        }

        public ActionResult GetRecipe(int id)
        {
            var recipe = new RecipeDTO();

            using (var ctx = new DataAccessLayer.BeerCalculatorEntities())
            {
                var result = ctx.Recipes.Where(r => r.RecipeID == id).FirstOrDefault();
                recipe =
                        new RecipeDTO
                        {
                            ActualABV = result.ActualABV.HasValue ? result.ActualABV.Value : 0.0,
                            ActualFG = result.ActualFG.HasValue ? result.ActualFG.Value : 0.0,
                            ActualOG = result.ActualOG.HasValue ? result.ActualOG.Value : 0.0,
                            BrewDate = result.BrewDate.HasValue ? result.BrewDate.Value : new DateTime(),
                            IBU = result.IBU.HasValue ? result.IBU.Value : 0,
                            MashEfficiency = result.MashEfficiency.HasValue ? result.MashEfficiency.Value : 0,
                            RecipeID = result.RecipeID,
                            RecipeName = result.RecipeName ?? string.Empty
                        }
                    ;
            }
            return Json(recipe);
        }

        public ActionResult CreateRecipe(RecipeDTO create)
        {
            using (var ctx = new DataAccessLayer.BeerCalculatorEntities())
            {
                var r = new DataAccessLayer.Recipe
                {
                    ActualABV = create.ActualABV,
                    ActualFG = create.ActualFG,
                    ActualOG = create.ActualOG,
                    BrewDate = create.BrewDate,
                    ExpectedABV = create.ExpectedABV,
                    ExpectedFG = create.ExpectedFG,
                    ExpectedOG = create.ExpectedOG,
                    IBU = create.IBU,
                    MashEfficiency = create.MashEfficiency,
                    RecipeName = create.RecipeName
                };
                ctx.SaveChanges();
            }

            create.Message = "Success";

            return Json(create);
        }

        public ActionResult UpdateRecipe(RecipeDTO update)
        {
            return null;
        }

        public ActionResult DeleteRecipe(int id)
        {
            return null;
        }
    }
}

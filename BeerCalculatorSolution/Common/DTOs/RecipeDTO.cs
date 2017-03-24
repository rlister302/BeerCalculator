using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstract;

namespace Common.DTOs
{
    [Controller("Recipe")]
    [GetAllAction("GetAllRecipes")]
    [GetDetailsAction("GetRecipeDetails")]
    [CreateAction("CreateRecipe")]
    [UpdateAction("UpdateRecipe")]
    [DeleteAction("DeleteRecipe")]
    public class RecipeDTO : ModelBase
    {
        public int RecipeID { get; set; }
        public string RecipeName { get; set; }
        public double ExpectedABV { get; set; }
        public double ActualABV { get; set; }
        public double ExpectedOG { get; set; }
        public double ActualOG { get; set; }
        public double ExpectedFG { get; set; }
        public double ActualFG { get; set; }
        public int IBU { get; set; }
        public int MashEfficiency { get; set; }
        public DateTime BrewDate { get; set; }

        public IEnumerable<HopTypeDTO> Hops { get; set; }

        public IEnumerable<GrainTypeDTO> Grains { get; set; }

        public YeastTypeDTO Yeast { get; set; }
    }
}

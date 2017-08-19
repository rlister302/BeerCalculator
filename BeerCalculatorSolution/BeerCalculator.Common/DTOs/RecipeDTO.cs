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
        public decimal ExpectedABV { get; set; }
        public decimal ActualABV { get; set; }
        public decimal ExpectedOG { get; set; }
        public decimal ActualOG { get; set; }
        public decimal ExpectedFG { get; set; }
        public decimal ActualFG { get; set; }
        public int IBU { get; set; }
        public int MashEfficiency { get; set; }
        public DateTime BrewDate { get; set; }

        public IEnumerable<HopTypeDTO> Hops { get; set; }

        public IEnumerable<GrainTypeDTO> Grains { get; set; }

        public YeastTypeDTO Yeast { get; set; }
    }
}

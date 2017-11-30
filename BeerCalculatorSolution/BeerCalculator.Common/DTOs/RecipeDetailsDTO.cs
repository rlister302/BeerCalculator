using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Common.DTOs
{
    public class RecipeDetailsDTO
    {
        public RecipeDTO Recipe { get; set; }

        public IngredientDTO Ingredients { get; set; }
    }
}

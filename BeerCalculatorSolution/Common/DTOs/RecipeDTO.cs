using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstract;

namespace Common.DTOs
{
<<<<<<< HEAD:BeerCalculatorSolution/Common/DTOs/RecipeDTO.cs
    public class RecipeDTO : ModelBase
=======
    public class RecipeDTO
>>>>>>> 4d4d2b14b50f429e520bea005f5107de2f1c95da:BeerCalculatorSolution/Models/Models/RecipeDTO.cs
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
    }
}

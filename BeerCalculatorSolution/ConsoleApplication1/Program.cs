using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            GetHops();
            Console.ReadKey();
        }
        static void GetHops()
        {
            using (var ctx = new DataAccessLayer.BeerCalculatorEntities())
            {
                var queryResult = ctx.Recipes.Where(r => r.RecipeName.Equals("Summer Lager", StringComparison.OrdinalIgnoreCase)).ToList();

                Console.WriteLine(queryResult.Count);
            }
        }
    }
}

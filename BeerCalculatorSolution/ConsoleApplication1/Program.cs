using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using log4net;
using Common.Communication;
namespace ConsoleApplication1
{
    class Program
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            try
            {
                var x = new RecipeRequestManager();
                var y =  x.RetreiveAll(new Common.DTOs.RecipeDTO());
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                log.Error(e.InnerException);
            }
            Console.WriteLine("Please Press a Key");
            Console.ReadKey();
        }
        static void GetHops()
        {
            using (var ctx = new DataAccessLayer.BeerCalculatorEntities())
            {
                try
                {
                    //deprecated
                    //var hopsList = ctx.Hops.Where
                    //    (h => h.RecipeID == ctx.Recipes.Where(r => r.RecipeName.Equals("Summer Lager", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().RecipeID);

                    //DataAccessLayer.Grain myObj = null;

                    //myObj.Amount = 10;

                    //Console.WriteLine(hopsList.Count());
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}

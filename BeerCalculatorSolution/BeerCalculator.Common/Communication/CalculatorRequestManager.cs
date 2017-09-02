using BeerCalculator.Common.Abstract;
using BeerCalculator.Common.DTOs;
using BeerCalculator.Common.Implementation;
using BeerCalculator.Common.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Common.Communication
{
    public class CalculatorRequestManager
    {
        public async Task<IRecipeMetrics> GetMetrics(IRecipeInput recipeInput)
        { 

            if (recipeInput is ModelBase)
            {
                ModelBase modelBase = recipeInput as ModelBase;

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BeerServiceURL"]);
                    string controllerName = modelBase.GetControllerName();
                    string createAction = modelBase.GetCreateAction();
                    string targetUrl = String.Format("{0}/{1}/{2}", client.BaseAddress, controllerName, createAction);

                    var response = await client.PostAsJsonAsync<IRecipeInput>(targetUrl, recipeInput);

                    var content = await response.Content.ReadAsStringAsync();

                    return await Task.Run(() => JsonConvert.DeserializeObject<IRecipeMetrics>(content));
                }

            }
            else
            {
                    // Need to modify the request managers to return a container with object instead of just object
                return await Task.Run(() => new RecipeMetrics());
            }
            

        }
    }
}

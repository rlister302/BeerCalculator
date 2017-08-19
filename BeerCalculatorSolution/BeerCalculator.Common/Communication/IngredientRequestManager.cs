using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTOs;
using Common.Abstract;
using Newtonsoft.Json;
using System.Net.Http;
using System.Configuration;

namespace Common.Communication
{
    
    public class IngredientRequestManager : AbstractRequestManager<IngredientDTO>
    {
        public override async Task<IngredientDTO> Retreive(IngredientDTO retreive)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BeerServiceURL"]);
                var controllerName = retreive.GetControllerName();
                var actionName = retreive.GetAllActionName();
                string targetUrl = String.Format("{0}/{1}/{2}", client.BaseAddress, controllerName, actionName);

                var response = await client.GetAsync(targetUrl);
                var content = await response.Content.ReadAsStringAsync();

                return await Task.Run(() => JsonConvert.DeserializeObject<IngredientDTO>(content));
            }
        }
    }
}

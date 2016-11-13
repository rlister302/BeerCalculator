using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Configuration;
using Models.Models;
using Newtonsoft.Json;

namespace Models.Communication
{
    public class RequestManager
    {
        private HttpClient _client;

        public RequestManager()
        {
            _client = new HttpClient();
            string baseUrl = ConfigurationManager.AppSettings["BeerServiceURL"];
            _client.BaseAddress = new Uri(baseUrl);
        }

        public async Task<RecipeDTO> Test()
        {
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "Home/GetItem");
            request.Content = new StringContent("{\"id\" : \"1\"}", Encoding.UTF8, "application/json");
    
            var response = await _client.SendAsync(request);
            

            string content = await response.Content.ReadAsStringAsync();

            return await Task.Run(() => JsonConvert.DeserializeObject<RecipeDTO>(content));
            
        }
    }
}

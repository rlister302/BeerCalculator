using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using System.Net.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using System.Configuration;
namespace Models.Communication
{
    public class HopRequestManager : IRequestManager<HopTypeDTO>
    {
        public async Task<HopTypeDTO> Create(HopTypeDTO create)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BeerServiceURL"]);

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "HopType/CreateHopType");
                var serializedObject = JsonConvert.SerializeObject(create);



                var response = await client.PostAsJsonAsync<HopTypeDTO>(client.BaseAddress + "/HopType/CreateHopType", create);

                string content = await response.Content.ReadAsStringAsync();

                return await Task.Run(() => JsonConvert.DeserializeObject<HopTypeDTO>(content));
            }
        }

        public Task<HopTypeDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<HopTypeDTO> Retreive()
        {
            throw new NotImplementedException();
        }

        public Task<HopTypeDTO> Retreive(int id)
        {
            throw new NotImplementedException();
        }

        public Task<HopTypeDTO> Update(HopTypeDTO update)
        {
            throw new NotImplementedException();
        }
    }
}

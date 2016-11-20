using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;


namespace Common.Abstract
{
    public class AbstractRequestManager<T> : IRequestManager<T> where T : ModelBase
    {
        public async Task<bool> Create(T create)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BeerServiceURL"]);
                string controllerName = create.GetControllerName();
                string createAction = create.GetCreateAction();
                string targetUrl = String.Format("{0}/{1}/{2}", client.BaseAddress, controllerName, createAction);

                var response = await client.PostAsJsonAsync<T>(targetUrl, create);

                var content = await response.Content.ReadAsStringAsync();

                return await Task.Run(() => JsonConvert.DeserializeObject<bool>(content));
            }
        }

        public async Task<bool> Delete(T delete)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BeerServiceURL"]);
                string controllerName = delete.GetControllerName();
                string deleteAction = delete.GetDeleteAction();
                int id = delete.GetPrimaryKeyValue();
                string targetUrl = String.Format("{0}/{1}/{2}/{3}", client.BaseAddress, controllerName, deleteAction, id);

                var response = await client.DeleteAsync(targetUrl);

                var content = await response.Content.ReadAsStringAsync();

                return await Task.Run(() => JsonConvert.DeserializeObject<bool>(content));
            }
        }

        public async Task<List<T>> RetreiveAll(T retreive)
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

                return await Task.Run(() => JsonConvert.DeserializeObject<List<T>>(content));
            }
        }

        public async Task<T> Retreive(T retreive)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BeerServiceURL"]);
                var controllerName = retreive.GetControllerName();
                var actionName = retreive.GetAllActionName();
                var id = retreive.GetPrimaryKeyValue();
                string targetUrl = String.Format("{0}/{1}/{2}/{3}", client.BaseAddress, controllerName, actionName, id);

                var response = await client.GetAsync(targetUrl);
                var content = await response.Content.ReadAsStringAsync();

                return await Task.Run(() => JsonConvert.DeserializeObject<T>(content));
            }
        }

        public async Task<bool> Update(T update)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BeerServiceURL"]);
                var controllerName = update.GetControllerName();
                var actionName = update.GetUpdateAction();
                string targetUrl = String.Format("{0}/{1}/{2}", client.BaseAddress, controllerName, actionName);
                var response = await client.PutAsJsonAsync<T>(targetUrl, update);
                var content = await response.Content.ReadAsStringAsync();

                return await Task.Run(() => JsonConvert.DeserializeObject<bool>(content));

            }
        }
    }
}

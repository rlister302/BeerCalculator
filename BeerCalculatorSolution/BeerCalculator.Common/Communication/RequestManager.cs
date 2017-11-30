using BeerCalculator.Common.Abstract;
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
    public class RequestManager : IRequestManager
    {
        #region Protected Members

        protected HttpClient client;

        #endregion

        #region Interface Methods
        public virtual async Task<object> GetAll(ModelBase retreive, Type deserializeTo)
        {
            using (client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string targetUrl = GetTargetUrl(retreive.GetControllerName(), retreive.GetAllActionName());
                var response = await client.GetAsync(targetUrl);
                var content = await response.Content.ReadAsStringAsync();
                return await Task.Run(() => Deserialize(content, deserializeTo));
            }
        }

        public virtual async Task<object> Get(ModelBase retreive, Type deserializeTo)
        {
            using (client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string targetUrl = GetTargetUrl(retreive.GetControllerName(), retreive.GetDetailsAction(), retreive.GetPrimaryKeyValue());
                var response = await client.GetAsync(targetUrl);
                var content = await response.Content.ReadAsStringAsync();
                return await Task.Run(() => Deserialize(content, deserializeTo));
            }
        }

        public virtual async Task<object> Create(ModelBase create, Type deserializeTo)
        {
            using (client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string targetUrl = GetTargetUrl(create.GetControllerName(), create.GetCreateAction());
                StringContent content = new StringContent(JsonConvert.SerializeObject(create));
                var rawResponse = await client.PostAsync(targetUrl, content);
                var response = await rawResponse.Content.ReadAsStringAsync();
                return await Task.Run(() => Deserialize(response, deserializeTo));
            }
        }

        public virtual async Task<object> Update(ModelBase update, Type deserializeTo)
        {
            using (client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string targetUrl = GetTargetUrl(update.GetControllerName(), update.GetUpdateAction());
                StringContent httpContent = new StringContent(JsonConvert.SerializeObject(update));
                var response = await client.PutAsync(targetUrl, httpContent);
                var content = await response.Content.ReadAsStringAsync();
                return await Task.Run(() => Deserialize(content, deserializeTo));

            }
        }

        public virtual async Task<object> Delete(ModelBase delete, Type deserializeTo)
        {
            using (client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string targetUrl = GetTargetUrl(delete.GetControllerName(), delete.GetDeleteAction(), delete.GetPrimaryKeyValue());
                var response = await client.DeleteAsync(targetUrl);
                var content = await response.Content.ReadAsStringAsync();
                return await Task.Run(() => Deserialize(content, deserializeTo));
            }
        }

        #endregion

        #region Protected Methods

        protected string GetTargetUrl(string controllerName, string actionName, int? id = null)
        {
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BeerServiceURL"]);
            string targetUrl =
                id == null ? String.Format("{0}/{1}/{2}", client.BaseAddress, controllerName, actionName)
                : String.Format("{0}/{1}/{2}/{3}", client.BaseAddress, controllerName, actionName, id);
            return targetUrl;
        }

        protected object Deserialize(string content, Type deserializeTo)
        {
            object o = JsonConvert.DeserializeObject(content, deserializeTo);
            return o;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using SecondWebAPI.Controllers;

namespace SecondWebAPI.Request
{
    public class Requestor
    {
        private HttpResponseMessage response;
        private readonly string serviceApiUrl = ConfigurationManager.AppSettings["ServiceUrl"];
        #region constants
        private const string GetAllUrl = "Items";

        private const string GetIdUrl = "Items/{0}";

        private const string UpdateUrl = "Items/{0}";

        private const string CreateUrl = "Items";

        private const string DeleteUrl = "Items/{0}";

        private readonly HomeController controller;

        public Requestor(HomeController controller)
        {
            this.controller = controller;
        }
        #endregion

        public async Task<IHttpActionResult> Get()
        {
            HttpClient client = new HttpClient();

            try
            {
                response = await client.GetAsync(serviceApiUrl + GetAllUrl);

                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                return controller.BadRequest(ex.Message);
            }

            return controller.Ok(await response.Content.ReadAsStringAsync());
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    response = await client.GetAsync(string.Format(serviceApiUrl + GetIdUrl, id));

                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException ex)
                {
                    return controller.BadRequest(ex.Message);
                }
            }
            return controller.Ok(await response.Content.ReadAsStringAsync());
        }


        public async Task<IHttpActionResult> Post(object item)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Accept.Add(
                       new MediaTypeWithQualityHeaderValue("application/json"));

                    response = await client.PostAsJsonAsync(serviceApiUrl + CreateUrl, item);

                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException ex)
                {
                    return controller.BadRequest(ex.Message);
                }
            }
            return controller.Ok(response.StatusCode);
        }

        public async Task<IHttpActionResult> Put(int id, object item)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    response = await client.PutAsJsonAsync(string.Format(serviceApiUrl + UpdateUrl, id), item);

                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException ex)
                {
                    return controller.BadRequest(ex.Message);
                }
            }
            return controller.Ok(response.StatusCode);
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    response = await client.DeleteAsync(string.Format(serviceApiUrl + DeleteUrl, id));

                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException ex)
                {
                    return controller.BadRequest(ex.Message);
                }
            }
            return controller.Ok(await response.Content.ReadAsStringAsync());
        }
    }
}
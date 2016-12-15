using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SecondWebAPI.Controllers
{
    public class HomeController : ApiController
    {
        private HttpResponseMessage response;
        // GET: api/Home
        public IHttpActionResult Get()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://localhost:65355/");

                    response = client.GetAsync("api/Items").Result;

                    response.EnsureSuccessStatusCode();
                }
                catch
                {
                    return BadRequest();
                }
            }

            return Ok(response.Content.ReadAsStringAsync());
        }

        //public async Task<IHttpActionResult> GetAsync()
        //{
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response;

        //    try
        //    {
        //        response = await client.GetAsync("http://localhost:65355/api/Items");

        //        foreach (var item in "1qwefrwqef223")
        //        {
        //            var d = item;
        //        }

        //       // response = await s;
        //        response.EnsureSuccessStatusCode();
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(response.Content.ReadAsStringAsync());
        //}
        // GET: api/Home/5

        public IHttpActionResult Get(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://localhost:65355/");
                    response = client.GetAsync($"api/Items/{id}").Result;

                    response.EnsureSuccessStatusCode();
                }
                catch
                {
                    return BadRequest();
                }
            }
            return Ok(response.Content.ReadAsStringAsync());
        }

        // POST: api/Home
        public IHttpActionResult Post([FromBody]object item)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://localhost:65355/");

                    client.DefaultRequestHeaders.Accept.Add(
                       new MediaTypeWithQualityHeaderValue("application/json"));

                    response = client.PostAsJsonAsync($"api/Items/", item).Result;

                    response.EnsureSuccessStatusCode();
                }
                catch
                {
                    return BadRequest();
                }
            }
            return Ok(response.StatusCode);
        }

        // PUT: api/Home/5
        public IHttpActionResult Put(int id, [FromBody]object item)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://localhost:65355/");

                    client.DefaultRequestHeaders.Accept.Add(
                       new MediaTypeWithQualityHeaderValue("application/json"));
                    
                    response = client.PutAsJsonAsync($"api/Items/{id}", item).Result;

                    response.EnsureSuccessStatusCode();
                }
                catch
                {
                    return BadRequest();
                }
            }
            return Ok(response.StatusCode);
        }

        // DELETE: api/Home/5
        public IHttpActionResult Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://localhost:65355/");

                    response = client.DeleteAsync($"api/Items/{id}").Result;

                    response.EnsureSuccessStatusCode();
                }
                catch
                {
                    return BadRequest();
                }
            }

            return Ok(response.Content.ReadAsStringAsync());
        }
    }
}

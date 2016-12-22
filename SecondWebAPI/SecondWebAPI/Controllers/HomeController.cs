using SecondWebAPI.Authentication;
using SecondWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using SecondWebAPI.Request;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace SecondWebAPI.Controllers
{
    [Authorize]
    public class HomeController : ApiController
    {
        private Requestor request;

        public HomeController()
        {
            this.request = new Requestor(this);
        }

        protected virtual new UserPrincipal User
        {
            get { return HttpContext.Current.User as UserPrincipal; }
        }

        // GET: api/Home
        [HttpGet]
        public async Task<IHttpActionResult> GetAsync()
        {
            return await request.Get();
        }

        // GET: api/Home/5
        [HttpGet]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            return await request.Get(id);
        }

        // POST: api/Home
        [HttpPost]
        public async Task<IHttpActionResult> PostAsync([FromBody]object item)
        {
            return await request.Post(item);
        }

        // PUT: api/Home/5
        [HttpPut]
        public async Task<IHttpActionResult> PutAsync(int id, [FromBody]object item)
        {
            return await request.Put(id, item);
        }

        // DELETE: api/Home/5
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            return await request.Delete(id);
        }

        [NonAction]
        public new BadRequestErrorMessageResult BadRequest(string message)
        {
            return base.BadRequest(message);
        }

        [NonAction]
        public new OkNegotiatedContentResult<T> Ok<T>(T content)
        {
            return base.Ok(content);
        }
    }
}

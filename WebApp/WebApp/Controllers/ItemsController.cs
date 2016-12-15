using DAL;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Web.Http;
using WebApp.Mapp;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ItemsController : ApiController
    {
        private IRepository<Item> repository = new ItemReopsitory();

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(repository.Get());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {

            return Ok(repository.Get(id));
        }

        [HttpPut]
        public IHttpActionResult Put(int id, ClientItem item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.Id)
            {
                return BadRequest();
            }

            var notFound = repository.UpDate(id, item.ToItem());
            if (!notFound)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public IHttpActionResult Post(ClientItem item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bad = repository.Add(item.ToItem());

            if (!bad)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var notFound = repository.Delete(id);
            if (!notFound)
            {
                return NotFound();
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
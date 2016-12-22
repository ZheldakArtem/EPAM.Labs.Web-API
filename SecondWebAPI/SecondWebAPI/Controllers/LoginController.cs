using SecondWebAPI.Attr;
using SecondWebAPI.Authentication;
using SecondWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Web.Security;
using static SecondWebAPI.Authentication.UserPrincipal;

namespace SecondWebAPI.Controllers
{
    [Authorize]
    public class LoginController : ApiController
    {
        public readonly IRepository<User> repository = new UserRepository();
        private HttpResponseMessage response;

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Login(LoginBindingModel model)
        {
            var user = repository.FindByPredicate(u => u.Login == model.Login && u.Password == model.Password);
            if (ReferenceEquals(user, null))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            UserPrincipalSerializeModel serializeModel = new UserPrincipalSerializeModel();
            serializeModel.Login = user.Login;

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string userData = serializer.Serialize(serializeModel);

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                     1,
                     model.Login,
                     DateTime.Now,
                     DateTime.Now.AddDays(1),
                     false,
                     userData);

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            var cookie = new CookieHeaderValue(FormsAuthentication.FormsCookieName, encTicket);
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            return response;
        }

        [HttpGet]
        [DeleteCookie]
        public IHttpActionResult Logout()
        {
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

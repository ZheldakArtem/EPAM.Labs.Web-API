using SecondWebAPI.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using static SecondWebAPI.Authentication.UserPrincipal;

namespace SecondWebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null && authCookie.Value != "")
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                UserPrincipalSerializeModel serializeModel = serializer.Deserialize<UserPrincipalSerializeModel>(authTicket.UserData);

                UserPrincipal newUser = new UserPrincipal(authTicket.Name);
                newUser.Login = serializeModel.Login;

                HttpContext.Current.User = newUser;
            }
        }
        protected void Application_EndRequest()
        {
            if (HttpContext.Current.Items["remove-auth-cookie"]!=null)
            {
                Context.Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
            }
        }
    }
}

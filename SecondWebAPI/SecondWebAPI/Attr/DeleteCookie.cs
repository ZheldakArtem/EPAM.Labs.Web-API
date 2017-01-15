using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace SecondWebAPI.Attr
{
    public class DeleteCookieAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            HttpContext.Current.Items.Add("remove-auth-cookie", "true");
        }
    }
}
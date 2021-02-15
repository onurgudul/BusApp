using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TepeBusApp.Web.Models;

namespace TepeBusApp.Web.Filters
{
    public class Auth : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (SessionManager.User == null)
            {
                filterContext.Result = new RedirectResult("/Auth/Login");
            }
        }
    }
}
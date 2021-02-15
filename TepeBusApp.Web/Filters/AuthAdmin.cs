using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TepeBusApp.Web.Models;

namespace TepeBusApp.Web.Filters
{
    public class AuthAdmin : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (SessionManager.User!=null && SessionManager.User.isAdmin==false)
            {
                filterContext.Result = new RedirectResult("/Shared/Error");
            }
        }
    }
}
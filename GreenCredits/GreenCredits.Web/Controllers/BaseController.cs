using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace GreenCredits.Web.Controllers
{
    public class BaseController:Controller
    {
       protected override void OnAuthorization(AuthorizationContext filterContext)
        {
           if(Session["id"] != null) 
           {
               base.OnAuthorization(filterContext);
               return;
           }
           filterContext.Result = new RedirectResult("/login");
           
        }
    }
}

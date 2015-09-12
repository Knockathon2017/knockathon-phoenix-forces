﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace GreenCredits.Web.Controllers
{
    public class BaseController:Controller
    {
       protected virtual void OnAuthorization(AuthorizationContext filterContext)
        {
           if(Session["email"] != null) 
           {
               base.OnAuthorization(filterContext);
               return;
           }
           filterContext.Result = new RedirectResult("/");
           
        }
    }
}

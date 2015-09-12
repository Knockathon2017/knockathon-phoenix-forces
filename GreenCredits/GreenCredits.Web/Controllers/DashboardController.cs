using GreenCredits.DAL;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenCredits.Web.Controllers
{
  
    public class DashboardController : BaseController
    {
        
        public ActionResult Index()
        {
            ViewBag.UserFullName = (Session["user"] as Farmer).FullName ;
            var model = ObjectFactory.GetInstance<IFarmerRepository>().GetByFramerId(Session["id"] as long?);
            return View(model);
        }
    }
}
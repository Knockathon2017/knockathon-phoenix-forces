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
            var model = ObjectFactory.GetInstance<IFarmerRepository>().GetByFramerId(18);
            return View(model);
        }
    }
}
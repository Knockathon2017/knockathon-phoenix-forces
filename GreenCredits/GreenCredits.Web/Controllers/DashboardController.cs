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
            var model = ObjectFactory.GetInstance<IFarmerRepository>().GetByFramerId(Session["id"] as long?);
            //var model = new List<CarbonAsset>();
            return View(model);
        }

        public ActionResult Traders()
        {
            var traders =ObjectFactory.GetInstance<IFarmerRepository>().GetTraders();
            return View(@"~/Views/Dashboard/TradersListView.cshtml",traders);
        }
    }
}
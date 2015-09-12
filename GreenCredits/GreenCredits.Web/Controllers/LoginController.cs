using GreenCredits.DAL;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenCredits.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        // Post: Login
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var user = ObjectFactory.GetInstance<IFarmerRepository>().Find(collection["email"]);
            if (user != null && collection["password"] == user.Password)
            {
                Session["email"] = user.email;
                Session["password"] = user.Password;
                return RedirectToRoute("/dashboard");
            }
            return View();
        }
        
        public ActionResult Logout()
        {

            Session.Clear();
            return View("Index");
        }
    }
}
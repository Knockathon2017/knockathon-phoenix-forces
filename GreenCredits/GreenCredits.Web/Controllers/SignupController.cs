using GreenCredits.DAL;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenCredits.Web.Controllers
{
    public class SignupController : Controller
    {
        // GET: Signup
        public ActionResult Index()
        {
            return View();
        }

        // GET: Signup/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Signup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Signup/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var email = collection["email"];
                if (!string.IsNullOrEmpty(email))
                {
                    if (ObjectFactory.GetInstance<IFarmerRepository>().Find(email) == null)
                    {
                        var farmer = new Farmer() { email = email };
                        ObjectFactory.GetInstance<IFarmerRepository>().Add(farmer);
                        ViewBag.FarmerId = farmer.id.ToString();
                        TempData["FarmerId"] = farmer.id.ToString();
                        return RedirectToAction("Index");
                    }

                }
                // TODO: Add insert logic here
                return new RedirectResult("/login");
                
            }
            catch
            {
                
            }
            return new RedirectResult("/home");
        }

        // GET: Signup/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Signup/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var user = ObjectFactory.GetInstance<IFarmerRepository>().FindById(long.Parse(collection["userId"]));
                Session["id"] = user.id;
                Session["user"] = user;
                Session["password"] = user.Password;
                return Json(new { data = collection["usertype"], status = 200 }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return View();
            }
        }

        // GET: Signup/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Signup/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ConfirmEmail()
        {
            return View("ConfirmEmail.cshtml");
        }

        [HttpPost]
        public ActionResult ConfirmEmail(FormCollection collection)
        {
            return View("ConfirmEmail.cshtml");
        }
    }
}

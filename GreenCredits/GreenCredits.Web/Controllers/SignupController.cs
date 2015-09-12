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
                if(!string.IsNullOrEmpty(email))
                {
                    ObjectFactory.GetInstance<IFarmerRepository>().Add(new Farmer() { email = email });

                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Signup/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Signup/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
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
    }
}

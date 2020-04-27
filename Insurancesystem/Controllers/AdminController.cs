using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Insurancesystem.Models;
using Insurancesystem.ViewModel;
using System.Data.Entity;
namespace Insurancesystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        InsuranceDBEntities3 db = new InsuranceDBEntities3();
        public ActionResult CusContact(CusContact cus)
        {
            return View(db.CusContacts.ToList());
        }
        public ActionResult Car(Car car)
        {
            return View(db.Cars.ToList());
        }
        public ActionResult Claim(Claim cl)
        {
            return View(db.Claims.ToList());
        }
        public ActionResult Motorview(Motorbike mo)
        {
            return View(db.Motorbikes.ToList());
        }
        public ActionResult USER(USER uSER)
        {
            return View(db.USERs.ToList());
        }
        public ActionResult ModifyUser(int? ID)
        {
            USER u = db.USERs.Find(ID);
            return View(u);
        }
        [HttpPost]
        public ActionResult ModifyUser(USER uSER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("USER", "Admin");
            }
            return View(uSER);
        }
    }
}
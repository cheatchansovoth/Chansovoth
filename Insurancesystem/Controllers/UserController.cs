using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Insurancesystem.Controllers;
using Insurancesystem.Models;
using Insurancesystem.ViewModel;
using System.Data.Entity;

namespace Insurancesystem.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        InsuranceDBEntities3 db = new InsuranceDBEntities3();
        public ActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResetPassword(UserCk uc)
        {
            var check = db.USERs.Where(x => x.Email == uc.Email).Count();
            TempData.Keep();
            if (check == 0)
            {
                return RedirectToAction("LoginMe", "Insurance");
            }
            else
            {
                return RedirectToAction("PwChange", "User");
            }


        }
        /*public ActionResult Forgotpassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Forgotpassword(forpass pw)
        {
            if (ModelState.IsValid)
            {

                USER u3 = new USER();

                u3.Email = pw.Email;
                u3.Password = pw.Password;
                db.Entry(u3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }*/
    }
}
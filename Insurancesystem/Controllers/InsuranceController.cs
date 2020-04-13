using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using Insurancesystem.Models;
using Insurancesystem.ViewModel;

namespace Insurancesystem.Controllers
{
    public class InsuranceController : Controller
    {
        InsuranceDBEntities10 db = new InsuranceDBEntities10();
        // GET: Insurance
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {

            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(CusContact cus)
        {
            if (ModelState.IsValid)
            {
                db.CusContacts.Add(cus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Testing()
        {
            return View();
        }
        public ActionResult carinformation()
        {
            return View();
        }
        public ActionResult motorinformation()
        {
            return View();
        }
        public ActionResult Policy()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Registerview re)
        {
            User user = new User();
            user.Email = re.Email;
            user.Firstname = re.Firstname;
            user.Lastname = re.Lastname;
            user.Password = re.Password;
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        
     }
 }
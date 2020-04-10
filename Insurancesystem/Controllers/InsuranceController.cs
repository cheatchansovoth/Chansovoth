using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using Insurancesystem.Models;

namespace Insurancesystem.Controllers
{
    public class InsuranceController : Controller
    {
        InsuranceDBEntities5 db = new InsuranceDBEntities5();
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
        
     }
 }
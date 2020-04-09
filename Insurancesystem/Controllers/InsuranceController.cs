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
        InsuranceDBEntities3 db = new InsuranceDBEntities3();
        // GET: Insurance
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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
        public ActionResult onCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult onCreate(InsuranceUser user)
        {
                if (ModelState.IsValid)
                {
                    db.InsuranceUsers.Add(user);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");

        }
        public ActionResult createCar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createCar(Car car)
        {
                if (ModelState.IsValid)
                {
                    db.Cars.Add(car);
                    db.SaveChanges();
                }
                return RedirectToAction("OnCreate");
        }
        public ActionResult createMotor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createMotor(MotorBike motor)
        {
                if (ModelState.IsValid)
                {
                    db.MotorBikes.Add(motor);
                    db.SaveChanges();
                }
                return RedirectToAction("OnCreate");
        }
        public ActionResult Claimform()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Claimform(Claim claim)
        {
            if (ModelState.IsValid)
            {
                db.Claims.Add(claim);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(InsuranceUser user)
        {
            int sx = db.InsuranceUsers.Where(x => x.Username == user.Username).Count();
            if (sx == 0)
            {
                ViewBag.msg = "Check your username and password";
                return RedirectToAction("Login", user);
            }
            else
            {
                var User = db.InsuranceUsers.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();
                return RedirectToAction("Index");
            }
        }
     }
 }
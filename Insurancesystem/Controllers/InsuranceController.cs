using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Data.Entity;
using Insurancesystem.Models;
using Insurancesystem.ViewModel;
using System.Security.Permissions;
using System.Web.Security;

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

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Registerview re)
        {
            //checking duplicate data 
            int sc = db.USERs.Where(x => x.Email == re.Email).Count();
            if (sc == 0)
            {
                TempData["user"] = re;
                TempData.Keep();
                return RedirectToAction("Regcar");
            }
            else
            {
                TempData["Message"]="This email has been used.Please try another email";
                return RedirectToAction("Register", "Insurance");
                
            }
            return View(re);
        }
        public ActionResult Regcar()
        {
            UserCarRegister cr = new UserCarRegister();
            Registerview r1 = (Registerview)TempData["user"];
            cr.UserID = r1.UserID;
            cr.Firstname = r1.Firstname;
            cr.Lastname = r1.Lastname;
            cr.Email = r1.Email;
            cr.Password = r1.Password;
            cr.Repassword = r1.Repassword;
            return View(cr);
        }
        [HttpPost]
        public ActionResult Regcar(UserCarRegister uc)
        {
            USER u = new USER { FirstName = uc.Firstname, LastName = uc.Lastname, Email = uc.Email, Password = uc.Password };
            Car car = new Car { ModeOfUse = uc.ModeOfUse, Car1 = uc.Car1, CarValue = uc.CarValue, CarRegisternumber = uc.CarRegisternumber };

            if (ModelState.IsValid)
            {
                db.USERs.Add(u);
                db.SaveChanges();
                car.UserID = u.UserID;
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("LoginMe", "Insurance");
            }

            return View();
        }
        public ActionResult MoReig()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MoReig(Registerview reg)
        {
            //checking duplicate data 
            int sc = db.USERs.Where(x => x.Email == reg.Email).Count();
            if (sc == 0)
            {
                TempData["user"] = reg;
                TempData.Keep();
                return RedirectToAction("MotorRegister");
            }
            else
            {
                TempData["Message"] = "This email has been used.Please try another email";
                return RedirectToAction("Register", "Insurance");
               
            }
            return View(reg);
        }
        public ActionResult MotorRegister()
        {
            UserMotorRegister u = new UserMotorRegister();
            Registerview r2 = (Registerview)TempData["user"];
            u.Firstname = r2.Firstname;
            u.Lastname = r2.Lastname;
            u.Email = r2.Email;
            u.Password = r2.Password;
            u.Repassword = r2.Repassword;
            return View(u);
        }
        [HttpPost]
        public ActionResult MotorRegister(UserMotorRegister um)
        {
            USER u = new USER { FirstName = um.Firstname, LastName = um.Lastname, Email = um.Email, Password = um.Password };
            Motorbike mk = new Motorbike { ModeOfUse = um.ModeOfUse, MotorRegisternumber = um.MotorRegisternumber, MotorValue = um.MotorValue };
            if (ModelState.IsValid)
            {
                db.USERs.Add(u);
                db.SaveChanges();
                mk.UserID = u.UserID;
                db.Motorbikes.Add(mk);
                db.SaveChanges();
                return RedirectToAction("LoginMe", "Insurance");

            }
            return View();
        }
        public ActionResult TestingLog()    
        {
            return View();
        }
        public ActionResult LoginMe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginMe(Userlogin lo)
        {
            int sx = db.USERs.Where(x => x.Email == lo.Email).Count();
            if (sx == 0)
            {
                TempData["Message"] = "Check your username and password";
                return RedirectToAction("LoginMe");
            }
            else
            {
                var User = db.USERs.Where(x => x.Email == lo.Email && x.Password == lo.Password).FirstOrDefault();
                //Create Session
                Session["UserID"] = User.UserID;
                Session["Email"] = User.Email;
                Session["Firstname"] = User.FirstName;
                Session["Lastname"] = User.LastName;
                if (User.UserID == 4)
                {
                    return RedirectToAction("USER","Admin");
                }
                else
                {   
                return RedirectToAction("MyDetails");
                }
            }
        }
        public ActionResult MyDetails()
        {
            USER u2 = db.USERs.Find(Convert.ToInt32(Session["UserID"]));

            UserView ul = new UserView();
            try
            {
                if (ul.Firstname == null)
                {
                    TempData["Message"] = "User required to login!!";
                    return RedirectToAction("LoginMe","Insurance");
                }
                else
                {
                    ul.Firstname = u2.FirstName;
                    ul.Lastname = u2.LastName;
                    ul.Email = u2.Email;
                }
                
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return View(ul);

        }
        public ActionResult EditDetails()
        {
            USER uSER = db.USERs.Find(Convert.ToInt32(Session["UserID"]));
            UserView uv = new UserView();
            uv.Firstname = uSER.FirstName;
            uv.Lastname = uSER.LastName;
            uv.Email = uSER.Email;
            uv.Password = uSER.Password;
            return View(uv);

        }
        [HttpPost]
        public ActionResult EditDetails(UserView ul)
        {
            if (ModelState.IsValid)
            {
                USER u4 = new USER();
                u4.UserID = (Convert.ToInt32(Session["UserID"]));
                u4.FirstName = ul.Firstname;
                u4.LastName = ul.Lastname;
                u4.Email = ul.Email;
                u4.Password = ul.Password;
                db.Entry(u4).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.msg = "User is Modified";
                return RedirectToAction("MyDetails");
            }
            else
            {
                ViewBag.msg = "UserName is already exsting !";
                return View(ul);
            }
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("LoginMe", "Insurance");
        }
        /*public ActionResult Forgot(Request f)
        {
            var ckl = db.USERs.Where(x => x.Email == f.Email).Count();
            if (ckl == 1)
            {
                var User1 = db.USERs.Where(x => x.Email == f.Email).FirstOrDefault();
                return RedirectToAction("LoginMe");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Forget(Request f)
        {
            var ckl = db.USERs.Where(x => x.Email == f.Email).Count();
            if (ckl == 0)
            {
                return RedirectToAction("Index");
            }
            else 
            {
                var User1 = db.USERs.Where(x => x.Email == f.Email).FirstOrDefault();
                return RedirectToAction("LoginMe");
            }
        }*/
        public ActionResult Claiminsurance()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Claiminsurance(UserClaim c)
        {
            USER uSER = new USER();
            int check = db.USERs.Where(x => x.Email == c.Email).Count();

            if (check == 1)
            {
                Claim cc = new Claim { ClaimID = c.ClaimID, Nature = c.Nature, Location = c.Location, Date = c.Date };

                if (ModelState.IsValid)
                {
                    cc.Date = DateTime.Now;
                    cc.UserID =Convert.ToInt32(Session["UserID"]);
                    db.Claims.Add(cc);
                    db.SaveChanges();
                    return RedirectToAction("LoginMe", "Insurance");
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
            return View();


        }
      

    }
}
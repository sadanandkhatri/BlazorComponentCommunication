using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ecommerce1.Models;

namespace Ecommerce1.Controllers
{
    public class LogInLogOutController : Controller
    {

        new_ecommerceEntities db = new new_ecommerceEntities();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserRegistration user)
        {
            if (db.Users.Any(x => x.UserName == user.Username))
            {

                if (user.IsOwner)
                {
                    return RedirectToAction("Index", "VendorReg");

                }
                else
                {
                    return RedirectToAction("HomeP", "Home",user);
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View();

        }

        
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User signup)
        {
             signup.UserId = db.Users.Select(t => t.UserId).DefaultIfEmpty(0).Max();
            db.Users.Add(signup);
                
            
            try
            {
                db.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Login");
        }



        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}

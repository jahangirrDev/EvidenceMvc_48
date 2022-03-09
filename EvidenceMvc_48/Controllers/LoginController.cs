using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EvidenceMvc_48.Controllers
{
    public class LoginController : System.Web.Mvc.Controller
    {

        public ActionResult LogOn( string ReturnUrl)
        {
            ViewBag.returnUrl = ReturnUrl;
            return View();

        }


        [HttpPost]
        public ActionResult LogOn(string name, string password, string ReturnUrl)
        {
            ViewBag.returnUrl = ReturnUrl;

            if (FormsAuthentication.Authenticate(name, password) == true)
            {
                FormsAuthentication.SetAuthCookie(name, true);
                return Redirect(ReturnUrl);
            }

            return View();

        }


        
        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "CourseDetail");

        }
    }
}
using ArchitectNetLDAP.LDAPServiceReference;
using ArchitectNetLDAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ArchitectNetLDAP.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }
            return Redirect("/Home");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnurl)
        {
            if (ModelState.IsValid)
            {
                bool isAuthenticated = false;

                try
                {
                    using (var client = new LDAPLoginServiceClient())
                    {
                        var response = client.Login(new LoginRequest { Domain = model.Domain, Username = model.Username, Password = model.Password });
                        isAuthenticated = response.IsOK;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }

                if (isAuthenticated)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, true);
                    if (string.IsNullOrEmpty(returnurl))
                        return Json("OK");
                    else
                        return Redirect(returnurl);
                }
                else
                {
                    ModelState.AddModelError("", "Access Denied");
                    return Json("Access Denied");
                }
            }
            return Json("Access Denied");
            //return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}
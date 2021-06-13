using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student_Managment.Models;
using System.Web.Security;

namespace BytesAndBits.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(userregistration model)
        {
            using (var context = new UserDBEntities())
            {
                FormsAuthentication.SetAuthCookie(model.login, false);

                bool isValid = context.userregistrations.Any(x => x.login == model.login && x.password == model.password);

                if (isValid)
                {
                    return RedirectToAction("Index", "UserName");
                }
                ModelState.AddModelError("", "Invalid LoginId and Password");
                return View();
            }



        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
  
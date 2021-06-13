using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Managment.Controllers
{
    [Authorize]
    public class UserNameController : Controller
    {
        // GET: UserName
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EAD_Project.Models;

namespace EAD_Project.Controllers
{
    public class HomeController : Controller
    {
        DatabaseEntities db = new DatabaseEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult userlogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult confirmLogin()
        {
            user u = new user();
            string nm = Request["username"];
            string pass = Request["password"];
            var obj = db.users.Where(query => query.username.Equals(nm) && query.password.Equals(pass)).SingleOrDefault();

            if(obj != null)
            {
                FormsAuthentication.SetAuthCookie(nm, false);
                return RedirectToAction("index");

            }
            return View();
        }

        public ActionResult signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveCredientials()
        {
            string uname = Request["Name"];
            string pass = Request["password"];
            user u = new user();
            u.username = uname;
            u.password = pass;
            u.type = "customer";
            db.users.Add(u);
            db.SaveChanges();
            return RedirectToAction("createaccount");
        }

        public ActionResult createaccount()
        {
            return View();
        }
    }
}
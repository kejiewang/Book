using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Book.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        public ActionResult Check(String LoginName, String PWD)
        {
            Book.Model.T_Base_Admin admin = new Book.BLL.T_Base_Home().check(LoginName, PWD);
            if(admin.LoginName.Equals("-1") && admin.PWD.Equals("-1"))
                return Redirect("Login");
            else
            {

                //进行记录票据
                FormsAuthentication.SetAuthCookie(LoginName, true);
                var authTicket = new FormsAuthenticationTicket(
                    admin.RoleId,
                    admin.LoginName,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    true,
                    "");
                HttpCookie authCookie = new HttpCookie(
                    FormsAuthentication.FormsCookieName,
                    FormsAuthentication.Encrypt(authTicket)
                    );
                Response.Cookies.Add(authCookie);
                return RedirectToAction("index", "home");

            }
        }
	}
}
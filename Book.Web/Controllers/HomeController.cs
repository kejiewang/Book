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
            Book.BLL.T_Base_Admin admin = new BLL.T_Base_Admin();
            ViewBag.admin = admin.GetCount();

            Book.BLL.T_Base_Book book = new BLL.T_Base_Book();
            ViewBag.book = book.GetCount();

            Book.BLL.T_Base_Provider provider = new BLL.T_Base_Provider();
            ViewBag.provider = provider.GetCount();

            Book.BLL.T_Base_Customer customer = new BLL.T_Base_Customer();
            ViewBag.customer = provider.GetCount();

            Book.BLL.T_Stock_Report stock = new BLL.T_Stock_Report();
            ViewBag.stock = stock.GetCount();


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

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login", "home");
        }
	}
}
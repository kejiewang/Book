using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security;

namespace Book.Web.Controllers
{

    [Authorize]
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetList(int pageSize, int pageIndex)
        {
            Book.BLL.T_Base_User bll = new Book.BLL.T_Base_User();
            List<Book.Model.T_Base_User> lst = new List<Model.T_Base_User>();
            lst = bll.GetList(pageIndex, pageSize);
            int count = bll.GetCount();
            return Json(new { total = count, rows = lst });

        }
	}
}
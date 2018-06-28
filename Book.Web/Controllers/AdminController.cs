using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security;


namespace Book.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        int PageSize = 5;
        int MaxPageIndex = 8;
        
        public JsonResult GetSearch(string Name = "", int matchCount = 10)
        {
            Name = Name.Trim();
            Book.BLL.T_Base_Admin bll = new BLL.T_Base_Admin();
            List<Book.Model.T_Base_Admin> lst = bll.GetSearch(Name, matchCount);

            return Json(lst);
        }


        public ActionResult Index(String Name = "")
        {
            Book.BLL.T_Base_Admin bll = new BLL.T_Base_Admin();

            Book.Model.T_Base_Admin_Page page = bll.GetListPage(1, PageSize, Name);
            //List<Book.Model.T_Base_Admin> lst = bll.GetAll();
            ViewBag.MaxPageIndex = MaxPageIndex;

            ViewBag.PageSize = PageSize;

            ViewBag.lst = page.list;
            ViewBag.count = page.count;
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult AddSave(string LoginName, string PWD, int RoleId)
        {
            Book.Model.T_Base_Admin Admin = new Model.T_Base_Admin();
            Admin.LoginName = LoginName;
            Admin.PWD = PWD;
            Admin.RoleId = RoleId;
            Book.BLL.T_Base_Admin bll = new BLL.T_Base_Admin();
            bll.Add(Admin);
            return Redirect("Index");
        }
        public ActionResult Delete(int Id)
        {
            Book.BLL.T_Base_Admin bll = new BLL.T_Base_Admin();
            int result = bll.Delete(Id);
            return RedirectToAction("Index");
        }

        public JsonResult DeleteJson(int Id)
        {
            Book.BLL.T_Base_Admin bll = new BLL.T_Base_Admin();
            int result = bll.Delete(Id);
            Book.Model.Message msg;
            if (result > 0)
            {
                msg = new Book.Model.Message() { Code = 200, Content = "删除成功" };
            }
            else
            {
                msg = new Book.Model.Message() { Code = 500, Content = "删除失败" };
            }
            return Json(msg);
        }

        public ActionResult Update(int Id)
        {
            Book.BLL.T_Base_Admin bll = new BLL.T_Base_Admin();
            Book.Model.T_Base_Admin Admin;
            Admin = bll.GetModal(Id);
            ViewBag.Admin = Admin;
            return View();
        }
        public ActionResult UpdateSave(Book.Model.T_Base_Admin Admin)
        {
            Book.BLL.T_Base_Admin bll = new BLL.T_Base_Admin();
            int result = bll.Update(Admin);

            return Redirect("Index");

        }

        public JsonResult GetList(int currentPage, String Name = "")
        {
            Book.BLL.T_Base_Admin bll = new BLL.T_Base_Admin();
            //List<Book.Model.T_Base_Admin> lst = bll.GetAll();
            List<Book.Model.T_Base_Admin> lst = bll.GetList(currentPage, PageSize, Name);

            ViewBag.Name = Name;

            int c = bll.GetCount(Name);
            return Json(new { count = c, result = Json(lst) });

        }
	}
}
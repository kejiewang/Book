using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Web.Controllers
{
    public class ProviderController : Controller
    {
        //
        // GET: /Provider/

        int PageSize = 5;
        int MaxPageIndex = 8;

        public JsonResult GetSearch(string Name = "", int matchCount = 10)
        {
            Name = Name.Trim();
            Book.BLL.T_Base_Provider bll = new BLL.T_Base_Provider();
            List<Book.Model.T_Base_Provider> lst = bll.GetSearch(Name, matchCount);

            return Json(lst);
        }
        public ActionResult Index(String Name = "")
        {
            Book.BLL.T_Base_Provider bll = new BLL.T_Base_Provider();

            Book.Model.T_Base_Provider_Page page = bll.GetListPage(1, PageSize,Name);
            //List<Book.Model.T_Base_Provider> lst = bll.GetAll();
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
        public ActionResult AddSave(string Name, string Tel, string Fax, string Memo)
        {
            Book.Model.T_Base_Provider provider = new Model.T_Base_Provider();
            provider.Name = Name;
            provider.Tel = Tel;
            provider.Fax = Fax;
            provider.Memo = Memo;
            Book.BLL.T_Base_Provider bll = new BLL.T_Base_Provider();
            bll.Add(provider);
            return Redirect("Index");
        }
        public ActionResult Delete(int Id)
        {
            Book.BLL.T_Base_Provider bll = new BLL.T_Base_Provider();
            int result = bll.Delete(Id);
            return RedirectToAction("Index");
        }

        public JsonResult DeleteJson(int Id)
        {
            Book.BLL.T_Base_Provider bll = new BLL.T_Base_Provider();
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
            Book.BLL.T_Base_Provider bll = new BLL.T_Base_Provider();
            Book.Model.T_Base_Provider provider;
            provider = bll.GetModal(Id);
            ViewBag.provider = provider;
            return View();
        }
        public ActionResult UpdateSave(Book.Model.T_Base_Provider provider)
        {
            Book.BLL.T_Base_Provider bll = new BLL.T_Base_Provider();
            int result = bll.Update(provider);

            return Redirect("Index");

        }

        public JsonResult GetList(int currentPage,String Name = "")
        {
            Book.BLL.T_Base_Provider bll = new BLL.T_Base_Provider();
            //List<Book.Model.T_Base_Provider> lst = bll.GetAll();
            List<Book.Model.T_Base_Provider> lst = bll.GetList(currentPage, PageSize, Name);

            ViewBag.Name = Name;
            return Json(lst);

        }

    }
}

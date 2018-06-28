using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security;

namespace Book.Web.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        int PageSize = 5;
        int MaxPageIndex = 8;

        public JsonResult GetSearch(string Name = "", int matchCount = 10)
        {
            Name = Name.Trim();
            Book.BLL.T_Base_Customer bll = new BLL.T_Base_Customer();
            List<Book.Model.T_Base_Customer> lst = bll.GetSearch(Name, matchCount);

            return Json(lst);
        }
        public ActionResult Index(String Name = "")
        {
            Book.BLL.T_Base_Customer bll = new BLL.T_Base_Customer();

            Book.Model.T_Base_Customer_Page page = bll.GetListPage(1, PageSize, Name);
            //List<Book.Model.T_Base_Customer> lst = bll.GetAll();
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
            Book.Model.T_Base_Customer Customer = new Model.T_Base_Customer();
            Customer.Name = Name;
            Customer.Tel = Tel;
            Customer.Fax = Fax;
            Customer.Memo = Memo;
            Book.BLL.T_Base_Customer bll = new BLL.T_Base_Customer();
            bll.Add(Customer);
            return Redirect("Index");
        }
        public ActionResult Delete(int Id)
        {
            Book.BLL.T_Base_Customer bll = new BLL.T_Base_Customer();
            int result = bll.Delete(Id);
            return RedirectToAction("Index");
        }

        public JsonResult DeleteJson(int Id)
        {
            Book.BLL.T_Base_Customer bll = new BLL.T_Base_Customer();
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
            Book.BLL.T_Base_Customer bll = new BLL.T_Base_Customer();
            Book.Model.T_Base_Customer Customer;
            Customer = bll.GetModal(Id);
            ViewBag.Customer = Customer;
            return View();
        }
        public ActionResult UpdateSave(Book.Model.T_Base_Customer Customer)
        {
            Book.BLL.T_Base_Customer bll = new BLL.T_Base_Customer();
            int result = bll.Update(Customer);

            return Redirect("Index");

        }

        public JsonResult GetList(int currentPage, String Name = "")
        {
            Book.BLL.T_Base_Customer bll = new BLL.T_Base_Customer();
            //List<Book.Model.T_Base_Customer> lst = bll.GetAll();
            List<Book.Model.T_Base_Customer> lst = bll.GetList(currentPage, PageSize, Name);

            ViewBag.Name = Name;
            int c = bll.GetCount(Name);
            return Json(new { count = c, result = Json(lst) });

        }
	}
}
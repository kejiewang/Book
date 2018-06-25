using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Web.Controllers
{
    public class IndexController : Controller
    {

        int PageSize = 5;
        int MaxPageIndex = 8;
        // GET: Index
        public ActionResult Index()
        {
            Book.BLL.T_Base_Book bll = new BLL.T_Base_Book();

            Book.Model.T_Base_Book_Page page = bll.GetListPage(1, PageSize);
            //List<Book.Model.T_Base_Book> lst = bll.GetAll();
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
        public ActionResult AddSave(string BookName, string Author, string PressName, string SN, int Version, decimal Price)
        {
            Book.Model.T_Base_Book book = new Model.T_Base_Book();
            book.Author = Author;
            book.BookName = BookName;
            book.PressName = PressName;
            book.Price = Price;
            book.SN = SN;
            book.Version = Version;
            Book.BLL.T_Base_Book bll = new BLL.T_Base_Book();
            bll.Add(book);
            return Redirect("Index");
        }
        public ActionResult Delete(int Id)
        {
            Book.BLL.T_Base_Book bll = new BLL.T_Base_Book();
            int result = bll.Delete(Id);
            return RedirectToAction("Index");
        }

        public JsonResult DeleteJson(int Id)
        {
            Book.BLL.T_Base_Book bll = new BLL.T_Base_Book();
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
            Book.BLL.T_Base_Book bll = new BLL.T_Base_Book();
            Book.Model.T_Base_Book book;
            book = bll.GetModal(Id);
            ViewBag.book = book;
            return View();
        }
        public ActionResult UpdateSave(Book.Model.T_Base_Book book)
        {
            Book.BLL.T_Base_Book bll = new BLL.T_Base_Book();
            int result = bll.Update(book);

            return Redirect("Index");

        }

        public JsonResult GetList(int currentPage)
        {
            Book.BLL.T_Base_Book bll = new BLL.T_Base_Book();
            //List<Book.Model.T_Base_Book> lst = bll.GetAll();
            List<Book.Model.T_Base_Book> lst = bll.GetList(currentPage, PageSize);
            return Json(lst);

        }

        public JsonResult GetSearch(string SN)
        {
            // Name = Name.Trim();
            Book.BLL.T_Base_Book bll = new BLL.T_Base_Book();
            List<Book.Model.T_Base_Book> lst = bll.GetSearch(SN);//new List<Model.T_Base_Book>();
            return Json(lst);
        }

        public JsonResult GetFind(string SN)
        {
            Book.BLL.T_Base_Book bll = new BLL.T_Base_Book();
            List<Book.Model.T_Base_Book> lst = bll.GetFind(SN);
            return Json(lst);
        }



    }
}
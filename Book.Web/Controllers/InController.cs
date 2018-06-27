using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Book.Web.Attribute;


namespace Book.Web.Controllers
{
    public class InController : Controller
    {
        //
        // GET: /In/
        [RoleAuthorize]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Add()
        {

            return View();
        }

        //public JsonResult GetList()
        //{
        //    Book.BLL.T_Stock_In bll = new BLL.T_Stock_In();
        //    List<Book.Model.T_Stock_In> lst = new List<Model.T_Stock_In>();
        //    lst = bll.GetList(1, 10);
        //    return Json(lst);
        //}
        public JsonResult GetList(int pageSize, int pageIndex, String search = "")
        {
            Book.BLL.T_Stock_In bll = new BLL.T_Stock_In();
            List<Book.Model.T_Stock_In> lst = new List<Model.T_Stock_In>();
            lst = bll.GetList(pageIndex, pageSize,search);
            int count = bll.Count(search);
            return Json(new { total = count, rows = lst });

        }

        public JsonResult Delete(string[] stringId, string[] tt)
        {
            Book.BLL.T_Stock_In bll = new BLL.T_Stock_In();
            bll.Delete(stringId);

            return Json(new Book.Model.Message() { Code = 1, Content = "删除成功" });
            //return Json(new Book.Model.Message() { Code = 1, Content = "删除成功" });

        }


        public JsonResult GetModel(int HeadId)
        {
            Book.BLL.T_Stock_In bll = new BLL.T_Stock_In();
            Book.Model.T_Stock_In stockIn = bll.GetModel(HeadId);
            return Json(stockIn);

        }
        /*
        public JsonResult AddSave(Book.Model.T_Stock_InHead Head, Book.Model.T_Stock_InItems[] Items, Book.Model.Test test,String ok)
        {
            Book.BLL.T_Stock_In bll = new BLL.T_Stock_In();
            Book.Model.T_Stock_In inStock = new Model.T_Stock_In();
            inStock.Head = Head;
            inStock.Items = Items.ToList();
            bool result = bll.Add(inStock);
            if (result == true)
                return Json(new Book.Model.Message() { Code = 1, Content = "保存成功" });
            else
                return Json(new Book.Model.Message() { Code = 2, Content = "保存错误" });
        }*/
        public JsonResult AddSave(Book.Model.T_Stock_InHead Head, Book.Model.T_Stock_InItems[] Items)
        {
            Book.BLL.T_Stock_In bll = new BLL.T_Stock_In();
            Book.Model.T_Stock_In inStock = new Model.T_Stock_In();
            inStock.Head = Head;
            inStock.Items = Items.ToList();
            bool result = bll.Add(inStock);
            return Json(new Book.Model.Message() { Code = 1, Content = "保存成功" });
        }
    }
}

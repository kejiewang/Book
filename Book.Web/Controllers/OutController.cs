using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security;
using Book.Web.Attribute;



namespace Book.Web.Controllers
{

    [Authorize]
    public class OutController : Controller
    {
        //
        // GET: /Out/
        [RoleAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {

            return View();
        }

        public JsonResult AddSave(Book.Model.T_Stock_OutHead Head, Book.Model.T_Stock_OutItems[] Items)
        {
            Book.BLL.T_Stock_Out bll = new BLL.T_Stock_Out();
            Book.Model.T_Stock_Out inStock = new Model.T_Stock_Out();
            inStock.Head = Head;
            inStock.Items = Items.ToList();
            bool result = bll.Add(inStock);
            return Json(new Book.Model.Message() { Code = 1, Content = "保存成功" });
        }

        public JsonResult GetList(int pageSize, int pageIndex, String search = "")
        {
            Book.BLL.T_Stock_Out bll = new BLL.T_Stock_Out();
            List<Book.Model.T_Stock_Out> lst = new List<Model.T_Stock_Out>();
            lst = bll.GetList(pageIndex, pageSize, search);
            int count = bll.Count(search);
            return Json(new { total = count, rows = lst });
        }

        public JsonResult Delete(string[] stringId, string[] tt)
        {
            Book.BLL.T_Stock_Out bll = new BLL.T_Stock_Out();
            bll.Delete(stringId);
            return Json(new Book.Model.Message() { Code = 1, Content = "删除成功" });
            
        }

        public JsonResult GetModel(int HeadId)
        {
            Book.BLL.T_Stock_Out bll = new BLL.T_Stock_Out();
            Book.Model.T_Stock_Out stockIn = bll.GetModel(HeadId);
            return Json(stockIn);
        }

        public JsonResult GetModel2(int HeadId)
        {
            Book.BLL.T_Stock_Out bll = new BLL.T_Stock_Out();
            Book.Model.T_Stock_Out stockIn = bll.GetModel(HeadId);
            List<Book.Model.T_Stock_OutItems> lst = stockIn.Items;
            List<Book.Model.EditItem> l = new List<Book.Model.EditItem>();
            foreach (Book.Model.T_Stock_OutItems it in lst)
            {
                Book.Model.EditItem ed = new Model.EditItem();
                ed.Id = it.Id;
                ed.Amount = it.Amount;
                ed.BookId = it.BookId;
                ed.BookName = it.Book.BookName;
                ed.Discount = it.Discount;
                ed.Price = it.Book.Price;
                ed.SN = it.Book.SN;
                ed.PressName = it.Book.PressName;
                l.Add(ed);
            }
            return Json(l);
        }

        public ActionResult Edit(int Id)
        {
            int id = Id;
            Book.BLL.T_Stock_Out bll = new BLL.T_Stock_Out();
            Book.Model.T_Stock_OutHead item = bll.GetHead(id);
            ViewBag.item = item;
            return View();
        }

        public JsonResult EditSave(Book.Model.T_Stock_OutHead Head, Book.Model.T_Stock_OutItems[] Items)
        {
            Book.BLL.T_Stock_Out bll = new BLL.T_Stock_Out();

            String[] tmp = new String[1];
            tmp[0] = "" + Head.Id;
            bll.Delete(tmp);
            Book.Model.T_Stock_Out inStock = new Model.T_Stock_Out();
            inStock.Head = Head;
            inStock.Items = Items.ToList();
            bool result = bll.Add(inStock);
            return Json(new Book.Model.Message() { Code = 1, Content = "保存成功" });
        }

	}
}
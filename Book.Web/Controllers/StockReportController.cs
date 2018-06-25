using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Web.Controllers
{
    public class StockReportController : Controller
    {
        //
        // GET: /StockReport/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetList(int pageSize, int pageIndex)
        {
            Book.BLL.T_Stock_Report bll = new Book.BLL.T_Stock_Report();
            List<Book.Model.T_Stock_Report> lst = new List<Model.T_Stock_Report>();
            lst = bll.GetList(pageIndex, pageSize);
            int count = bll.GetCount();
            return Json(new { total = count, rows = lst });

        }

       
	}
}
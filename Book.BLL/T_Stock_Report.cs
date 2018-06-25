using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BLL
{
    public class T_Stock_Report
    {

        public int GetCount()
        {
            Book.DAL.T_Stock_Report dal = new DAL.T_Stock_Report();
            return dal.GetCount();
        }

        public List<Book.Model.T_Stock_Report> GetList(int CurrentPage, int PageSize)
        {
            Book.DAL.T_Stock_Report dal = new DAL.T_Stock_Report();
            return dal.GetList(CurrentPage, PageSize);
        }

    }
}

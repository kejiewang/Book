using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BLL
{
    public class T_Base_User
    {
        public int GetCount()
        {
            Book.DAL.T_Base_User dal = new DAL.T_Base_User();
            return dal.GetCount();
        }

        public List<Book.Model.T_Base_User> GetList(int CurrentPage, int PageSize)
        {
            Book.DAL.T_Base_User dal = new DAL.T_Base_User();
            return dal.GetList(CurrentPage, PageSize);
        }

    }
}

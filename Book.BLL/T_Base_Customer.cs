using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BLL
{
    public class T_Base_Customer
    {
        public List<Book.Model.T_Base_Customer> GetAll()
        {
            Book.DAL.T_Base_Customer dal = new DAL.T_Base_Customer();
            return dal.GetAll();
        }

        public int Add(Book.Model.T_Base_Customer Customer)
        {
            Book.DAL.T_Base_Customer dal = new DAL.T_Base_Customer();
            //用DAL层提供的添加方法添加
            dal.Add(Customer);
            return 0;
        }

        public int Delete(int Id)
        {
            Book.DAL.T_Base_Customer dal = new DAL.T_Base_Customer();
            int result = dal.Delete(Id);
            return result;
        }

        public Book.Model.T_Base_Customer GetModal(int Id)
        {
            Book.DAL.T_Base_Customer dal = new DAL.T_Base_Customer();

            return dal.GetModal(Id);
        }

        public int Update(Book.Model.T_Base_Customer Customer)
        {
            Book.DAL.T_Base_Customer dal = new DAL.T_Base_Customer();
            int result = dal.Update(Customer);
            return result;
        }

        public Book.Model.T_Base_Customer_Page GetListPage(int CurrentPage, int PageSize, String Name = "")
        {
            Book.DAL.T_Base_Customer dal = new DAL.T_Base_Customer();
            List<Book.Model.T_Base_Customer> list = dal.GetList(CurrentPage, PageSize, Name);
            int count = dal.GetCount(Name);
            Book.Model.T_Base_Customer_Page page = new Model.T_Base_Customer_Page();
            page.list = list;
            page.count = count;
            return page;

        }

        public List<Book.Model.T_Base_Customer> GetList(int currentPage, int pageSize, String Name = "")
        {
            Book.DAL.T_Base_Customer dal = new DAL.T_Base_Customer();
            List<Book.Model.T_Base_Customer> lst = dal.GetList(currentPage, pageSize, Name);
            return lst;
        }

        public List<Model.T_Base_Customer> GetSearch(string Name, int matchCount)
        {
            // throw new NotImplementedException();
            Book.DAL.T_Base_Customer dal = new DAL.T_Base_Customer();
            return dal.GetSearch(Name, matchCount);
        }
    }
}

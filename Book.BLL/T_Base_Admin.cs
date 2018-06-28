using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BLL
{
    public class T_Base_Admin
    {
        //public List<Book.Model.T_Base_Admin> GetAll()
        //{
        //    Book.DAL.T_Base_Admin dal = new DAL.T_Base_Admin();
        //    return dal.GetAll();
        //}

        public int Add(Book.Model.T_Base_Admin item)
        {
            Book.DAL.T_Base_Admin dal = new DAL.T_Base_Admin();
            //用DAL层提供的添加方法添加
            dal.Add(item);
            return 0;
        }

        public int Delete(int Id)
        {
            Book.DAL.T_Base_Admin dal = new DAL.T_Base_Admin();
            int result = dal.Delete(Id);
            return result;
        }

        public Book.Model.T_Base_Admin GetModal(int Id)
        {
            Book.DAL.T_Base_Admin dal = new DAL.T_Base_Admin();

            return dal.GetModal(Id);
        }

        public int Update(Book.Model.T_Base_Admin Admin)
        {
            Book.DAL.T_Base_Admin dal = new DAL.T_Base_Admin();
            int result = dal.Update(Admin);
            return result;
        }

        public Book.Model.T_Base_Admin_Page GetListPage(int CurrentPage, int PageSize, String Name = "")
        {
            Book.DAL.T_Base_Admin dal = new DAL.T_Base_Admin();
            List<Book.Model.T_Base_Admin> list = dal.GetList(CurrentPage, PageSize, Name);
            int count = dal.GetCount(Name);
            Book.Model.T_Base_Admin_Page page = new Model.T_Base_Admin_Page();
            page.list = list;
            page.count = count;
            return page;
        }

        public List<Book.Model.T_Base_Admin> GetList(int currentPage, int pageSize, String Name = "")
        {
            Book.DAL.T_Base_Admin dal = new DAL.T_Base_Admin();
            List<Book.Model.T_Base_Admin> lst = dal.GetList(currentPage, pageSize, Name);
            return lst;
        }

        public List<Model.T_Base_Admin> GetSearch(string Name, int matchCount)
        {
            // throw new NotImplementedException();
            Book.DAL.T_Base_Admin dal = new DAL.T_Base_Admin();
            return dal.GetSearch(Name, matchCount);
        }

        public int GetCount(String Name = "")
        {
            Book.DAL.T_Base_Admin dal = new DAL.T_Base_Admin();
            int count = dal.GetCount(Name);
            return count;
        }

    }
}

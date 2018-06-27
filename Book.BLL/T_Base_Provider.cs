using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BLL
{
    public class T_Base_Provider
    {
        public List<Book.Model.T_Base_Provider> GetAll()
        {
            Book.DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            return dal.GetAll();
        }

        public int Add(Book.Model.T_Base_Provider provider)
        {
            Book.DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            //用DAL层提供的添加方法添加
            dal.Add(provider);
            return 0;
        }

        public int Delete(int Id)
        {
            Book.DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            int result = dal.Delete(Id);
            return result;
        }

        public Book.Model.T_Base_Provider GetModal(int Id)
        {
            Book.DAL.T_Base_Provider dal = new DAL.T_Base_Provider();

            return dal.GetModal(Id);
        }

        public int Update(Book.Model.T_Base_Provider provider)
        {
            Book.DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            int result = dal.Update(provider);
            return result;
        }

        public Book.Model.T_Base_Provider_Page GetListPage(int CurrentPage, int PageSize, String Name = "")
        {
            Book.DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            List<Book.Model.T_Base_Provider> list = dal.GetList(CurrentPage, PageSize, Name);
            int count = dal.GetCount(Name);
            Book.Model.T_Base_Provider_Page page = new Model.T_Base_Provider_Page();
            page.list = list;
            page.count = count;
            return page;

        }

        public List<Book.Model.T_Base_Provider> GetList(int currentPage, int pageSize, String Name = "")
        {
            Book.DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            List<Book.Model.T_Base_Provider> lst = dal.GetList(currentPage, pageSize, Name);
            return lst;
        }

        public List<Model.T_Base_Provider> GetSearch(string Name, int matchCount)
        {
            // throw new NotImplementedException();
            Book.DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            return dal.GetSearch(Name, matchCount);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BLL
{
    public class T_Base_Book
    {
        public List<Book.Model.T_Base_Book> GetAll()
        {
            Book.DAL.T_Base_Book dal = new DAL.T_Base_Book();
            return dal.GetAll();
        }

        public int Add(Book.Model.T_Base_Book book)
        {
            Book.DAL.T_Base_Book dal = new DAL.T_Base_Book();
            //用DAL层提供的添加方法添加
            dal.Add(book);
            return 0;
        }

        public int Delete(int Id)
        {
            Book.DAL.T_Base_Book dal = new DAL.T_Base_Book();
            int result = dal.Delete(Id);
            return result;
        }

        public Book.Model.T_Base_Book GetModal(int Id)
        {
            Book.DAL.T_Base_Book dal = new DAL.T_Base_Book();

            return dal.GetModal(Id);
        }

        public int Update(Book.Model.T_Base_Book book)
        {
            Book.DAL.T_Base_Book dal = new DAL.T_Base_Book();
            int result = dal.Update(book);
            return result;
        }

        public Book.Model.T_Base_Book_Page GetListPage(int CurrentPage, int PageSize, String BookName = "", String Author = "")
        {
            Book.DAL.T_Base_Book dal = new DAL.T_Base_Book();
            List<Book.Model.T_Base_Book> list = dal.GetList(CurrentPage, PageSize,BookName, Author);
            int count = dal.GetCount(BookName, Author);
            Book.Model.T_Base_Book_Page page = new Model.T_Base_Book_Page();
            page.list = list;
            page.count = count;
            return page;

        }

        public List<Book.Model.T_Base_Book> GetList(int currentPage, int pageSize,String BookName = "", String Author = "")
        {
            Book.DAL.T_Base_Book dal = new DAL.T_Base_Book();
            List<Book.Model.T_Base_Book> lst = dal.GetList(currentPage, pageSize, BookName, Author);
            return lst;
        }

        public List<Model.T_Base_Book> GetSearch(string SN)
        {
            Book.DAL.T_Base_Book dal = new DAL.T_Base_Book();
            //throw new NotImplementedException();
            return dal.GetSearch(SN);
        }

        public List<Model.T_Base_Book> GetFind(string SN)
        {
            Book.DAL.T_Base_Book dal = new DAL.T_Base_Book();
            //throw new NotImplementedException();
            return dal.GetFind(SN);

            //throw new NotImplementedException();
        }

        public int GetCount(String BookName = "", String Author = "")
        {
            Book.DAL.T_Base_Book dal = new DAL.T_Base_Book();
            int count = dal.GetCount(BookName, Author);
            return count;
        }
    }
}

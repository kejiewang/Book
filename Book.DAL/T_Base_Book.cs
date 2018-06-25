using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Book.DAL
{
    public class T_Base_Book
    {

        public List<Book.Model.T_Base_Book> GetAll()
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select * from t_base_book";
            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Base_Book> lst = new List<Model.T_Base_Book>();
            while (dr.Read())
            {
                Book.Model.T_Base_Book book = new Model.T_Base_Book();
                book.Id = Convert.ToInt32(dr["Id"]);
                book.BookName = Convert.ToString(dr["BookName"]);
                book.PressName = Convert.ToString(dr["PressName"]);
                book.Author = Convert.ToString(dr["Author"]);
                book.Version = Convert.ToInt32(dr["Version"]);
                book.SN = Convert.ToString(dr["SN"]);
                book.Price = Convert.ToDecimal(dr["Price"]);
                lst.Add(book);
            }
            dr.Close();
            co.Close();
            return lst;
        }

        public int Add(Book.Model.T_Base_Book book)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "Insert into T_Base_Book(BookName,PressName,SN,Author,Version,Price) values (@BookName,@PressName,@SN,@Author,@Version,@Price)";
            cm.Parameters.AddWithValue("@BookName", book.BookName);
            cm.Parameters.AddWithValue("@PressName", book.PressName);
            cm.Parameters.AddWithValue("@SN", book.SN);
            cm.Parameters.AddWithValue("@Author", book.Author);
            cm.Parameters.AddWithValue("@Version", book.Version);
            cm.Parameters.AddWithValue("@Price", book.Price);
            int result = cm.ExecuteNonQuery();
            co.Close();
            return result;
        }

        public int Delete(int Id)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "delete from T_Base_Book where Id=@Id";
            cm.Parameters.AddWithValue("@Id", Id);
            int result = cm.ExecuteNonQuery();
            return result;
        }

        public Book.Model.T_Base_Book GetModal(int Id)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select * from T_Base_Book where Id=@Id";
            cm.Parameters.AddWithValue("@Id", Id);

            SqlDataReader dr = cm.ExecuteReader();
            Book.Model.T_Base_Book book = new Model.T_Base_Book();
            while (dr.Read())
            {

                book.Id = Convert.ToInt32(dr["Id"]);
                book.BookName = Convert.ToString(dr["BookName"]);
                book.PressName = Convert.ToString(dr["PressName"]);
                book.Author = Convert.ToString(dr["Author"]);
                book.Version = Convert.ToInt32(dr["Version"]);
                book.SN = Convert.ToString(dr["SN"]);
                book.Price = Convert.ToDecimal(dr["Price"]);
            }
            dr.Close();
            co.Close();
            return book;
        }

        public int Update(Book.Model.T_Base_Book book)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "update T_Base_Book set BookName=@BookName,PressName=@PressName,Author=@Author,Version=@Version,SN=@SN,Price=@Price where Id=@Id";

            cm.Parameters.AddWithValue("@BookName", book.BookName);
            cm.Parameters.AddWithValue("@PressName", book.PressName);
            cm.Parameters.AddWithValue("@Author", book.Author);
            cm.Parameters.AddWithValue("@Version", book.Version);
            cm.Parameters.AddWithValue("@SN", book.SN);
            cm.Parameters.AddWithValue("@Price", book.Price);
            cm.Parameters.AddWithValue("@Id", book.Id);

            int result = cm.ExecuteNonQuery();

            co.Close();
            return result;
        }

        public int GetCount()
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select count(1) from t_base_book";
            cm.Connection = co;
            object result = cm.ExecuteScalar();
            co.Close();
            return (int)result;

        }

        public List<Book.Model.T_Base_Book> GetList(int currentPage, int pageSize)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select top " + pageSize + " * from t_base_book where id not in (select top " + pageSize * (currentPage - 1) + " id from t_base_book)";

            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Base_Book> lst = new List<Model.T_Base_Book>();
            while (dr.Read())
            {
                Book.Model.T_Base_Book book = new Model.T_Base_Book();
                book.Id = Convert.ToInt32(dr["Id"]);
                book.BookName = Convert.ToString(dr["BookName"]);
                book.PressName = Convert.ToString(dr["PressName"]);
                book.Author = Convert.ToString(dr["Author"]);
                book.Version = Convert.ToInt32(dr["Version"]);
                book.SN = Convert.ToString(dr["SN"]);
                book.Price = Convert.ToDecimal(dr["Price"]);
                lst.Add(book);
            }
            dr.Close();
            co.Close();
            return lst;
        }

        public List<Model.T_Base_Book> GetSearch(string SN)
        {
            //throw new NotImplementedException();
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select * from t_base_book WHERE sn like '%" + SN + "%'";
            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Base_Book> lst = new List<Model.T_Base_Book>();
            while (dr.Read())
            {
                Book.Model.T_Base_Book book = new Model.T_Base_Book();
                book.Id = Convert.ToInt32(dr["Id"]);
                book.BookName = Convert.ToString(dr["BookName"]);
                book.PressName = Convert.ToString(dr["PressName"]);
                book.Author = Convert.ToString(dr["Author"]);
                book.Version = Convert.ToInt32(dr["Version"]);
                book.SN = Convert.ToString(dr["SN"]);
                book.Price = Convert.ToDecimal(dr["Price"]);
                lst.Add(book);
            }
            dr.Close();
            co.Close();
            return lst;
        }

        public List<Model.T_Base_Book> GetFind(string SN)
        {
            //throw new NotImplementedException();
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select * from t_base_book WHERE id = " + SN + "";
            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Base_Book> lst = new List<Model.T_Base_Book>();
            while (dr.Read())
            {
                Book.Model.T_Base_Book book = new Model.T_Base_Book();
                book.Id = Convert.ToInt32(dr["Id"]);
                book.BookName = Convert.ToString(dr["BookName"]);
                book.PressName = Convert.ToString(dr["PressName"]);
                book.Author = Convert.ToString(dr["Author"]);
                book.Version = Convert.ToInt32(dr["Version"]);
                book.SN = Convert.ToString(dr["SN"]);
                book.Price = Convert.ToDecimal(dr["Price"]);
                lst.Add(book);
            }
            dr.Close();
            co.Close();
            return lst;
        }
    }
}

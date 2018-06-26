using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Book.DAL
{

    public class T_Stock_In
    {
        public string connstring = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
        public List<Book.Model.T_Stock_In> GetList(int CurrentPage, int PageSize)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            //cm.CommandText = "select * from t_base_book";
            cm.CommandText = "select top " + PageSize + " * from  [V_InHead_Provider] where  id not in (select top " + PageSize * (CurrentPage - 1) + " id from [V_InHead_Provider] )";
            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Stock_In> lst = new List<Model.T_Stock_In>();
            while (dr.Read())
            {
                Book.Model.T_Stock_In inStock = new Model.T_Stock_In();

                Book.Model.T_Stock_InHead head = new Model.T_Stock_InHead();
                inStock.Id = head.Id = Convert.ToInt32(dr["Id"]);
                inStock.CreateTime = head.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                inStock.ProviderId = head.ProviderId = Convert.ToInt32(dr["ProviderId"]);
                inStock.TotalMoney = head.TotalMoney = Convert.ToDecimal(dr["TotalMoney"]);
                inStock.UserName = head.UserName = Convert.ToString(dr["UserName"]);
                Book.Model.T_Base_Provider provider = new Model.T_Base_Provider();
                provider.Id = Convert.ToInt32(dr["Id"]);
                provider.Name = Convert.ToString(dr["Name"]);
                provider.Tel = Convert.ToString(dr["Tel"]);
                provider.Fax = Convert.ToString(dr["Fax"]);
                provider.Memo = Convert.ToString(dr["Memo"]);
                head.Provider = provider;
                inStock.Head = head;
                inStock.Items = null;
                lst.Add(inStock);
            }
            dr.Close();
            co.Close();
            return lst;
        }

        public int Delete(string ids)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "delete from t_stock_inhead where id in (" + ids + ") ; ";
            cm.Connection = co;
            int result = cm.ExecuteNonQuery();
            co.Close();
            return result;
        }
        public int Count()
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select count(*) from T_Stock_InHead";
            int count = (int)cm.ExecuteScalar();
            return count;

        }
        public Book.Model.T_Stock_In GetModel(int HeadId)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();

            Book.Model.T_Stock_In stockIn = new Model.T_Stock_In();
            //stockIn.Head.Id = HeadId;
            stockIn.Head = null;
            stockIn.Items = new List<Model.T_Stock_InItems>();
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select * from V_InItem_Book where headid = @headid";
            cm.Parameters.AddWithValue("@headid", HeadId);
            cm.Connection = co;
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                Book.Model.T_Stock_InItems item = new Model.T_Stock_InItems();
                item.HeadId = HeadId;
                item.Id = Convert.ToInt32(dr["Id"]);
                item.Discount = Convert.ToDecimal(dr["Discount"]);
                Book.Model.T_Base_Book book = new Model.T_Base_Book();
                book.Author = Convert.ToString(dr["Author"]);
                book.BookName = Convert.ToString(dr["BookName"]);
                book.Id = Convert.ToInt32(dr["Id"]);
                book.PressName = Convert.ToString(dr["PressName"]);
                book.Price = Convert.ToDecimal(dr["Price"]);
                book.SN = Convert.ToString(dr["SN"]);
                book.Version = Convert.ToInt32(dr["Version"]);
                item.Book = book;
                item.Amount = Convert.ToInt32(dr["Amount"]);
                stockIn.Items.Add(item);
            }
            dr.Close();
            co.Close();
            return stockIn;
        }

        public bool Add(Model.T_Stock_In inStock)
        {
            //throw new NotImplementedException();
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlTransaction tran = co.BeginTransaction();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.Transaction = tran;
            try
            {
                cm.Parameters.Clear();
                cm.CommandText = "insert into t_stock_inhead (UserName,CreateTime,ProviderId,TotalMoney) values (@UserName,@CreateTime,@ProviderId,@TotalMoney); select @@identity";
                cm.Parameters.AddWithValue("@UserName", inStock.Head.UserName);
                cm.Parameters.AddWithValue("@ProviderId", inStock.Head.ProviderId);
                cm.Parameters.AddWithValue("@CreateTime", inStock.Head.CreateTime);
                cm.Parameters.AddWithValue("@TotalMoney", inStock.Head.TotalMoney);
                object result = cm.ExecuteScalar();
                int headId = Convert.ToInt32(result);
                foreach (Book.Model.T_Stock_InItems item in inStock.Items)
                {
                    cm.Parameters.Clear();
                    cm.CommandText = "insert into t_stock_initems (HeadId,BookId,Amount,Discount) values (@HeadId,@BookId,@Amount,@Discount)";
                    cm.Parameters.AddWithValue("@HeadId", headId);
                    cm.Parameters.AddWithValue("@BookId", item.BookId);
                    cm.Parameters.AddWithValue("@Amount", item.Amount);
                    cm.Parameters.AddWithValue("@Discount", item.Discount);
                    cm.ExecuteNonQuery();
                }
                tran.Commit();//提交   
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();//遇到错误，回滚
            }
            finally
            {
                co.Close();
            }
            return false;
        }
    }
}

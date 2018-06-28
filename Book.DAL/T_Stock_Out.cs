using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Book.DAL
{
    public class T_Stock_Out
    {
        public string connstring = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";

        public List<Book.Model.T_Stock_Out> GetList(int CurrentPage, int PageSize, String search = "")
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
      
            search = "'%" + search + "%'";
            cm.CommandText = "select top " + PageSize + " * from  [V_OutHead_Customer] where id not in (select top " + PageSize * (CurrentPage - 1) + " id from [V_OutHead_Customer] where (username like " + search + " or name like " + search + ")) and (username like " + search + " or name like " + search + ")";
            SqlDataReader dr = cm.ExecuteReader();
            
            List<Book.Model.T_Stock_Out> lst = new List<Model.T_Stock_Out>();
            while (dr.Read())
            {
                Book.Model.T_Stock_Out outStock = new Model.T_Stock_Out();
                outStock.Customer = new Model.T_Base_Customer();
                Book.Model.T_Stock_OutHead head = new Model.T_Stock_OutHead();
                outStock.Id = head.Id = Convert.ToInt32(dr["Id"]);
                head.Customer = new Model.T_Base_Customer();
                outStock.CreateTime = head.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                outStock.Customer.Id = head.Customer.Id = Convert.ToInt32(dr["CustomerId"]);
                outStock.TotalMoney = head.TotalMoney = Convert.ToDecimal(dr["TotalMoney"]);
                outStock.UserName = head.UserName = Convert.ToString(dr["UserName"]);
                Book.Model.T_Base_Customer Customer = new Model.T_Base_Customer();
                Customer.Id = Convert.ToInt32(dr["Id"]);
                Customer.Name = Convert.ToString(dr["Name"]);
                Customer.Tel = Convert.ToString(dr["Tel"]);
                Customer.Fax = Convert.ToString(dr["Fax"]);
                Customer.Memo = Convert.ToString(dr["Memo"]);
                head.Customer = Customer;
                outStock.Head = head;
                outStock.Items = null;
                lst.Add(outStock);
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
            cm.CommandText = "delete from t_stock_outhead where id in (" + ids + ") ; ";
            cm.Connection = co;
            int result = cm.ExecuteNonQuery();
            co.Close();
            return result;
        }

        public int Count(String search = "")
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            search = "'%" + search + "%'";
            cm.CommandText = "select count(*) from V_OutHead_Customer where name like " + search + " or username like " + search + "";
            int count = (int)cm.ExecuteScalar();
            return count;
        }

        public Book.Model.T_Stock_Out GetModel(int HeadId)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();

            Book.Model.T_Stock_Out stockIn = new Model.T_Stock_Out();
            //stockIn.Head.Id = HeadId;
            stockIn.Head = null;
            stockIn.Items = new List<Model.T_Stock_OutItems>();
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select * from V_OutItem_Book where headid = @headid";
            cm.Parameters.AddWithValue("@headid", HeadId);
            cm.Connection = co;
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                Book.Model.T_Stock_OutItems item = new Model.T_Stock_OutItems();
                item.HeadId = HeadId;
                item.Id = Convert.ToInt32(dr["Id"]);
                item.Discount = Convert.ToDecimal(dr["Discount"]);
                Book.Model.T_Base_Book book = new Model.T_Base_Book();
                book.Author = Convert.ToString(dr["Author"]);
                book.BookName = Convert.ToString(dr["BookName"]);
                book.Id = Convert.ToInt32(dr["BookId"]);
                book.PressName = Convert.ToString(dr["PressName"]);
                book.Price = Convert.ToDecimal(dr["Price"]);
                book.SN = Convert.ToString(dr["SN"]);
                book.Version = Convert.ToInt32(dr["Version"]);
                item.BookId = book.Id;
                item.Book = book;
                item.Amount = Convert.ToInt32(dr["Amount"]);
                stockIn.Items.Add(item);
            }
            dr.Close();
            co.Close();
            return stockIn;
        }

        public bool Add(Model.T_Stock_Out inStock)
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
                cm.CommandText = "insert into T_Stock_Outhead (UserName,CreateTime,CustomerId,TotalMoney) values (@UserName,@CreateTime,@ProviderId,@TotalMoney); select @@identity";
                cm.Parameters.AddWithValue("@UserName", inStock.Head.UserName);
                cm.Parameters.AddWithValue("@ProviderId", inStock.Head.CustomerId);
                cm.Parameters.AddWithValue("@CreateTime", inStock.Head.CreateTime);
                cm.Parameters.AddWithValue("@TotalMoney", inStock.Head.TotalMoney);
                object result = cm.ExecuteScalar();
                int headId = Convert.ToInt32(result);
                foreach (Book.Model.T_Stock_OutItems item in inStock.Items)
                {
                    cm.Parameters.Clear();
                    cm.CommandText = "insert into T_Stock_Outitems (HeadId,BookId,Amount,Discount) values (@HeadId,@BookId,@Amount,@Discount)";
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


        /// <summary>
        /// 根据表头获取相应的对象
        /// </summary>
        /// <param name="Id">图书的Id</param>
        /// <returns></returns>
        public Model.T_Stock_OutHead GetHead(int Id)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            Book.Model.T_Stock_OutHead item = new Model.T_Stock_OutHead();
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select * from V_OutHead_Customer where Id = @headid";
            cm.Parameters.AddWithValue("@headid", Id);
            cm.Connection = co;
            item.Customer = new Model.T_Base_Customer();
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                item.Id = Id;
                item.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                item.CustomerId = Convert.ToInt32(dr["CustomerId"]);
                item.UserName = Convert.ToString(dr["UserName"]);
                item.Customer.Name = Convert.ToString(dr["Name"]);
            }
            dr.Close();
            co.Close();

            return item;
        }


    }
}

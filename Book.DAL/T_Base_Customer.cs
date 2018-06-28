using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Book.DAL
{
    public class T_Base_Customer
    {

        public List<Book.Model.T_Base_Customer> GetAll()
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select * from t_base_Customer";
            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Base_Customer> lst = new List<Model.T_Base_Customer>();
            while (dr.Read())
            {
                Book.Model.T_Base_Customer Customer = new Model.T_Base_Customer();
                
                Customer.Id = Convert.ToInt32(dr["Id"]);
                Customer.Name = Convert.ToString(dr["Name"]);
                Customer.Tel = Convert.ToString(dr["Tel"]);
                Customer.Memo = Convert.ToString(dr["Memo"]);
                Customer.Fax = Convert.ToString(dr["Fax"]);
                lst.Add(Customer);
            }
            dr.Close();
            co.Close();
            return lst;
        }

        public int Add(Book.Model.T_Base_Customer Customer)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "Insert into T_Base_Customer(Name,Tel,Fax,Memo) values (@Name,@Tel,@Fax,@Memo)";
            cm.Parameters.AddWithValue("@Name", Customer.Name);
            cm.Parameters.AddWithValue("@Tel", Customer.Tel);
            cm.Parameters.AddWithValue("@Fax", Customer.Fax);
            cm.Parameters.AddWithValue("@Memo", Customer.Memo);
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
            cm.CommandText = "delete from T_Base_Customer where Id=@Id";
            cm.Parameters.AddWithValue("@Id", Id);
            int result = cm.ExecuteNonQuery();
            return result;
        }

        public Book.Model.T_Base_Customer GetModal(int Id)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select * from T_Base_Customer where Id=@Id";
            cm.Parameters.AddWithValue("@Id", Id);

            SqlDataReader dr = cm.ExecuteReader();
            Book.Model.T_Base_Customer Customer = new Model.T_Base_Customer();
            while (dr.Read())
            {

                Customer.Id = Convert.ToInt32(dr["Id"]);
                Customer.Name = Convert.ToString(dr["Name"]);
                Customer.Tel = Convert.ToString(dr["Tel"]);
                Customer.Fax = Convert.ToString(dr["Fax"]);
                Customer.Memo = Convert.ToString(dr["Memo"]);

            }
            dr.Close();
            co.Close();
            return Customer;
        }

        public int Update(Book.Model.T_Base_Customer Customer)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;

            cm.CommandText = "update T_Base_Customer set Name=@Name,Tel=@Tel,Fax=@Fax,Memo=@Memo where Id=@Id";
            cm.Parameters.AddWithValue("@Id", Customer.Id);
            cm.Parameters.AddWithValue("@Name", Customer.Name);
            cm.Parameters.AddWithValue("@Tel", Customer.Tel);
            cm.Parameters.AddWithValue("@Fax", Customer.Fax);
            cm.Parameters.AddWithValue("@Memo", Customer.Memo);

            int result = cm.ExecuteNonQuery();

            co.Close();
            return result;
        }

        public int GetCount(String Name = "")
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select count(1) from t_base_Customer where Name like '%" + Name + "%'";
            cm.Connection = co;
            object result = cm.ExecuteScalar();
            co.Close();
            return (int)result;

        }

        public List<Book.Model.T_Base_Customer> GetList(int currentPage, int pageSize, String Name = "")
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select top " + pageSize + " * from t_base_Customer where id not in (select top " + pageSize * (currentPage - 1) + " id from t_base_Customer where Name like '%" + Name + "%') and Name like '%" + Name + "%'";

            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Base_Customer> lst = new List<Model.T_Base_Customer>();
            while (dr.Read())
            {

                Book.Model.T_Base_Customer Customer = new Model.T_Base_Customer();
                Customer.Id = Convert.ToInt32(dr["Id"]);
                Customer.Name = Convert.ToString(dr["Name"]);
                Customer.Tel = Convert.ToString(dr["Tel"]);
                Customer.Memo = Convert.ToString(dr["Memo"]);
                Customer.Fax = Convert.ToString(dr["Fax"]);
                lst.Add(Customer);
            }
            dr.Close();
            co.Close();
            return lst;
        }



        public List<Model.T_Base_Customer> GetSearch(string Name, int matchCount)
        {
            //throw new NotImplementedException();
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select top " + matchCount + " * from t_base_Customer where Name like '%" + Name + "%'";
            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Base_Customer> lst = new List<Model.T_Base_Customer>();
            while (dr.Read())
            {
                Book.Model.T_Base_Customer item = new Model.T_Base_Customer();
                item.Id = Convert.ToInt32(dr["Id"]);
                item.Name = Convert.ToString(dr["Name"]);
                item.Tel = Convert.ToString(dr["Tel"]);
                item.Fax = Convert.ToString(dr["Fax"]);
                item.Memo = Convert.ToString(dr["Memo"]);
                lst.Add(item);
            }
            dr.Close();
            co.Close();
            return lst;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Book.DAL
{
    public class T_Base_Provider
    {
        public List<Book.Model.T_Base_Provider> GetAll()
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select * from t_base_provider";
            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Base_Provider> lst = new List<Model.T_Base_Provider>();
            while (dr.Read())
            {
                Book.Model.T_Base_Provider provider = new Model.T_Base_Provider();
                provider.Id = Convert.ToInt32(dr["Id"]);
                provider.Name = Convert.ToString(dr["Name"]);
                provider.Tel = Convert.ToString(dr["Tel"]);
                provider.Memo = Convert.ToString(dr["Memo"]);
                provider.Fax = Convert.ToString(dr["Fax"]);
                lst.Add(provider);
            }
            dr.Close();
            co.Close();
            return lst;
        }

        public int Add(Book.Model.T_Base_Provider provider)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "Insert into T_Base_Provider(Name,Tel,Fax,Memo) values (@Name,@Tel,@Fax,@Memo)";
            cm.Parameters.AddWithValue("@Name", provider.Name);
            cm.Parameters.AddWithValue("@Tel", provider.Tel);
            cm.Parameters.AddWithValue("@Fax", provider.Fax);
            cm.Parameters.AddWithValue("@Memo", provider.Memo);
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
            cm.CommandText = "delete from T_Base_Provider where Id=@Id";
            cm.Parameters.AddWithValue("@Id", Id);
            int result = cm.ExecuteNonQuery();
            return result;
        }

        public Book.Model.T_Base_Provider GetModal(int Id)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select * from T_Base_Provider where Id=@Id";
            cm.Parameters.AddWithValue("@Id", Id);

            SqlDataReader dr = cm.ExecuteReader();
            Book.Model.T_Base_Provider provider = new Model.T_Base_Provider();
            while (dr.Read())
            {

                provider.Id = Convert.ToInt32(dr["Id"]);
                provider.Name = Convert.ToString(dr["Name"]);
                provider.Tel = Convert.ToString(dr["Tel"]);
                provider.Fax = Convert.ToString(dr["Fax"]);
                provider.Memo = Convert.ToString(dr["Memo"]);

            }
            dr.Close();
            co.Close();
            return provider;
        }

        public int Update(Book.Model.T_Base_Provider provider)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;

            cm.CommandText = "update T_Base_Provider set Name=@Name,Tel=@Tel,Fax=@Fax,Memo=@Memo where Id=@Id";
            cm.Parameters.AddWithValue("@Id", provider.Id);
            cm.Parameters.AddWithValue("@Name", provider.Name);
            cm.Parameters.AddWithValue("@Tel", provider.Tel);
            cm.Parameters.AddWithValue("@Fax", provider.Fax);
            cm.Parameters.AddWithValue("@Memo", provider.Memo);

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
            cm.CommandText = "select count(1) from t_base_provider where Name like '%"+Name+"%'";
            cm.Connection = co;
            object result = cm.ExecuteScalar();
            co.Close();
            return (int)result;

        }

        public List<Book.Model.T_Base_Provider> GetList(int currentPage, int pageSize,String Name = "")
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select top " + pageSize + " * from t_base_provider where id not in (select top " + pageSize * (currentPage - 1) + " id from t_base_provider where Name like '%"+Name+"%') and Name like '%"+Name+"%'";

            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Base_Provider> lst = new List<Model.T_Base_Provider>();
            while (dr.Read())
            {

                Book.Model.T_Base_Provider provider = new Model.T_Base_Provider();
                provider.Id = Convert.ToInt32(dr["Id"]);
                provider.Name = Convert.ToString(dr["Name"]);
                provider.Tel = Convert.ToString(dr["Tel"]);
                provider.Memo = Convert.ToString(dr["Memo"]);
                provider.Fax = Convert.ToString(dr["Fax"]);
                lst.Add(provider);
            }
            dr.Close();
            co.Close();
            return lst;
        }



        public List<Model.T_Base_Provider> GetSearch(string Name, int matchCount)
        {
            //throw new NotImplementedException();
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select top " + matchCount + " * from t_base_provider where Name like '%" + Name + "%'";
            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Base_Provider> lst = new List<Model.T_Base_Provider>();
            while (dr.Read())
            {
                Book.Model.T_Base_Provider item = new Model.T_Base_Provider();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Book.DAL
{
    public class T_Base_Admin
    {


        //public List<Book.Model.T_Base_Provider> GetAll()
        //{
        //    SqlConnection co = new SqlConnection();
        //    co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
        //    co.Open();
        //    SqlCommand cm = new SqlCommand();
        //    cm.Connection = co;
        //    cm.CommandText = "select * from t_base_provider";
        //    SqlDataReader dr = cm.ExecuteReader();
        //    List<Book.Model.T_Base_Provider> lst = new List<Model.T_Base_Provider>();
        //    while (dr.Read())
        //    {
        //        Book.Model.T_Base_Provider provider = new Model.T_Base_Provider();
        //        provider.Id = Convert.ToInt32(dr["Id"]);
        //        provider.Name = Convert.ToString(dr["Name"]);
        //        provider.Tel = Convert.ToString(dr["Tel"]);
        //        provider.Memo = Convert.ToString(dr["Memo"]);
        //        provider.Fax = Convert.ToString(dr["Fax"]);
        //        lst.Add(provider);
        //    }
        //    dr.Close();
        //    co.Close();
        //    return lst;
        //}

        public int Add(Book.Model.T_Base_Admin item)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "Insert into T_Base_Admin(LoginName,PWD,RoleId) values (@LoginName,@PWD,@RoleId)";
            cm.Parameters.AddWithValue("@LoginName", item.LoginName);
            cm.Parameters.AddWithValue("@PWD", item.PWD);
            cm.Parameters.AddWithValue("@RoleId", item.RoleId);
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
            cm.CommandText = "delete from T_Base_Admin where Id=@Id";
            cm.Parameters.AddWithValue("@Id", Id);
            int result = cm.ExecuteNonQuery();
            return result;
        }

        public Book.Model.T_Base_Admin GetModal(int Id)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select * from V_Role_Admin where Id=@Id";
            cm.Parameters.AddWithValue("@Id", Id);

            SqlDataReader dr = cm.ExecuteReader();
            Book.Model.T_Base_Admin  item= new Model.T_Base_Admin();
            while (dr.Read())
            {

                item.Id = Convert.ToInt32(dr["Id"]);
                item.LoginName = Convert.ToString(dr["LoginName"]);
                item.PWD = Convert.ToString(dr["PWD"]);
                item.RoleName = Convert.ToString(dr["RoleName"]);
                item.RoleId = Convert.ToInt32(dr["RoleId"]);

            }
            dr.Close();
            co.Close();
            return item;
        }

        public int Update(Book.Model.T_Base_Admin item)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;

            cm.CommandText = "update T_Base_Admin set LoginName=@LoginName,PWD=@PWD,RoleId=@RoleId where Id=@Id";
            cm.Parameters.AddWithValue("@Id", item.Id);
            cm.Parameters.AddWithValue("@LoginName", item.LoginName);
            cm.Parameters.AddWithValue("@PWD", item.PWD);
            cm.Parameters.AddWithValue("@RoleId", item.RoleId);
            

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
            cm.CommandText = "select count(1) from t_base_admin where LoginName like '%" + Name + "%'";
            cm.Connection = co;
            object result = cm.ExecuteScalar();
            co.Close();
            return (int)result;

        }

        public List<Book.Model.T_Base_Admin> GetList(int currentPage, int pageSize, String Name = "")
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select top " + pageSize + " * from v_role_admin where id not in (select top " + pageSize * (currentPage - 1) + " id from v_role_admin where LoginName like '%" + Name + "%') and LoginName like '%" + Name + "%'";

            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Base_Admin> lst = new List<Model.T_Base_Admin>();
            while (dr.Read())
            {

                Book.Model.T_Base_Admin item = new Model.T_Base_Admin();
                item.Id = Convert.ToInt32(dr["Id"]);
                item.LoginName = Convert.ToString(dr["LoginName"]);
                item.PWD = Convert.ToString(dr["PWD"]);
                item.RoleName = Convert.ToString(dr["RoleName"]);
                item.RoleId = Convert.ToInt32(dr["RoleId"]);
                lst.Add(item);
            }
            dr.Close();
            co.Close();
            return lst;
        }



        public List<Model.T_Base_Admin> GetSearch(string Name, int matchCount)
        {
            //throw new NotImplementedException();
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select top " + matchCount + " * from T_Base_Role where RoleName like '%" + Name + "%'";
            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Base_Admin> lst = new List<Model.T_Base_Admin>();
            while (dr.Read())
            {
                Book.Model.T_Base_Admin item = new Model.T_Base_Admin();
                //item.Id = Convert.ToInt32(dr["Id"]);
                //item.LoginName = Convert.ToString(dr["LoginName"]);
                //item.PWD = Convert.ToString(dr["PWD"]);
                item.RoleName = Convert.ToString(dr["RoleName"]);
                item.RoleId = Convert.ToInt32(dr["Id"]);
                lst.Add(item);
            }
            dr.Close();
            co.Close();
            return lst;
        }

    }
}

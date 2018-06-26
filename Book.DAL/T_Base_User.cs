using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Book.DAL
{
    public class T_Base_User
    {
        public string connstring = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
        public int GetCount()
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select count(1) from T_Base_User";
            int result = (int)cm.ExecuteScalar();

            co.Close();
            return result;
        }

        public List<Book.Model.T_Base_User> GetList(int CurrentPage, int PageSize)
        {
            List<Book.Model.T_Base_User> lst = new List<Book.Model.T_Base_User>();
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select top " + PageSize + " * from  [T_Base_User] where  id not in (select top " + PageSize * (CurrentPage - 1) + " id from [T_Base_User] )";
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                Book.Model.T_Base_User item = new Model.T_Base_User();
                item.Id = Convert.ToInt32(dr["Id"]);
                item.Password = Convert.ToString(dr["Password"]);
                item.UserName = Convert.ToString(dr["UserName"]);
                lst.Add(item);
            }

            dr.Close();
            co.Close();

            return lst;
        }
    }
}

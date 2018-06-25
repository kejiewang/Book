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

        public List<T_Base_User> GetList()
        {
            List<T_Base_User> lst = new List<T_Base_User>();
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;


            return lst;

        }
    }
}

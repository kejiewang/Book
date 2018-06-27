using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Book.DAL
{
    public class T_Base_Home
    {
        public string connstring = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
        public Book.Model.T_Base_Admin check(String LoginName, String PWD)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select * from T_Base_Admin where LoginName = @LoginName and PWD = @PWD";
            cm.Parameters.AddWithValue("@LoginName", LoginName);
            cm.Parameters.AddWithValue("@PWD", PWD);
            SqlDataReader dr = cm.ExecuteReader();
            Book.Model.T_Base_Admin admin = new Model.T_Base_Admin();
            admin.LoginName = "-1";
            admin.PWD = "-1";
            while (dr.Read())
            {
                admin.LoginName = Convert.ToString(dr["LoginName"]);
                admin.PWD = Convert.ToString(dr["PWD"]);
                admin.RoleId = Convert.ToInt32(dr["RoleId"]);
            }

            dr.Close();
            co.Close();
            return admin;

        }

        public List<Book.Model.T_Base_Menu> GetMenuList(int RoleId)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select * from V_Role_Menu where RoleId = @RoleId";
            cm.Parameters.AddWithValue("@RoleId", RoleId);
            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Base_Menu> lst = new List<Model.T_Base_Menu>();

            while (dr.Read())
            {
                Book.Model.T_Base_Menu item = new Model.T_Base_Menu();
                item.Id = Convert.ToInt32(dr["Id"]);
                item.Action = Convert.ToString(dr["Action"]);
                item.Controller = Convert.ToString(dr["Controller"]);
                item.Display = Convert.ToString(dr["Display"]);
                item.Type = Convert.ToInt32(dr["Type"]);
                item.ParentId = Convert.ToInt32(dr["ParentId"]);
                lst.Add(item);
            }
            dr.Close();
            co.Close();

            return lst;
        }

        public List<Book.Model.T_Base_Menu> GetMenuList(int RoleId, string Controller, string Action)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select * from V_Role_Menu where RoleId = @RoleId and Controller=@Controller and Action=@Action ";
            cm.Parameters.AddWithValue("@RoleId", RoleId);
            cm.Parameters.AddWithValue("@Controller", Controller);
            cm.Parameters.AddWithValue("@Action", Action);

            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Base_Menu> lst = new List<Model.T_Base_Menu>();

            while (dr.Read())
            {
                Book.Model.T_Base_Menu item = new Model.T_Base_Menu();
                item.Id = Convert.ToInt32(dr["Id"]);
                item.Action = Convert.ToString(dr["Action"]);
                item.Controller = Convert.ToString(dr["Controller"]);
                item.Display = Convert.ToString(dr["Display"]);
                item.Type = Convert.ToInt32(dr["Type"]);
                item.ParentId = Convert.ToInt32(dr["ParentId"]);
                lst.Add(item);
            }
            dr.Close();
            co.Close();

            return lst;
        }
    }
}

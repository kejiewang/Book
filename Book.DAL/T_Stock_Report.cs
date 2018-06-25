using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Book.DAL
{
    public class T_Stock_Report
    {
        public string connstring = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113";
        public List<Book.Model.T_Stock_Report> GetList(int CurrentPage, int PageSize)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            //cm.CommandText = "select * from t_base_book";
            cm.CommandText = "select top " + PageSize + " * from  [V_Stock_BookItem] where  id not in (select top " + PageSize * (CurrentPage - 1) + " id from [V_Stock_BookItem] )";
            SqlDataReader dr = cm.ExecuteReader();
            List<Book.Model.T_Stock_Report> lst = new List<Model.T_Stock_Report>();
            while (dr.Read())
            {
                Book.Model.T_Stock_Report item = new Model.T_Stock_Report();
                item.BookName = Convert.ToString(dr["BookName"]);
                item.Count = Convert.ToInt32(dr["Count"]);
                lst.Add(item);
            }
            dr.Close();
            co.Close();
            return lst;
        }


        public int GetCount()
        {

            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select count (1) from V_Stock_BookItem";
            int count = (int)cm.ExecuteScalar();
            co.Close();

            return count;
            //throw new NotImplementedException();
        }
    }
}

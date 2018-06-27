using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BLL
{
    public class T_Base_Home
    {
        public Book.Model.T_Base_Admin check(String LoginName, String PWD)
        {
            return new Book.DAL.T_Base_Home().check(LoginName, PWD);
        }


        public List<Book.Model.T_Base_Menu> GetMenuList(int RoleId)
        {

            return new DAL.T_Base_Home().GetMenuList(RoleId);
        }

        public List<Book.Model.T_Base_Menu> GetMenuList(int RoleId, string Controller, string Action)
        {
            return new DAL.T_Base_Home().GetMenuList(RoleId, Controller, Action);
        }
    }
}

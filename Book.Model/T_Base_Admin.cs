using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Model
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class T_Base_Admin
    {

        public int Id { get; set; }
        public String LoginName { get; set; }
        public String PWD { get; set; }
        public int RoleId { get; set; }
        public String RoleName { get; set; }

    }

    public class T_Base_Admin_Page
    {
        public List<T_Base_Admin> list { get; set; }
        public int count { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Model
{
    public class T_Base_Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Memo { get; set; }
    }

    public class T_Base_Provider_Page
    {
        public List<T_Base_Provider> list { get; set; }
        public int count { get; set; }
    }
}

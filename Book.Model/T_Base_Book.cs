using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Model
{
    public class T_Base_Book
    {
        private decimal price = 0;

        public int Id { get; set; }
        public string BookName { get; set; }
        public string SN { get; set; }
        public string Author { get; set; }
        public string PressName { get; set; }
        public int Version { get; set; }
        public decimal Price { get { return price; } set { price = value; } }
    }

    public class T_Base_Book_Page
    {
        public List<T_Base_Book> list { get; set; }
        public int count { get; set; }
    }
}

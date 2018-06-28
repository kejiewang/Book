using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Model
{
    public class EditItem
    {
        public int Id { get; set; }
        public int BookId{ get; set; }
        public decimal Price { get; set; }
        public string SN { get; set; }
        public string BookName { get; set; }
        public decimal Discount { get; set; }
        public int Amount { get; set; }
        public string PressName { get; set; }
        public int ProviderId { get; set; }
    }

}

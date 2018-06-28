using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Model
{
    public class T_Stock_Out : T_Stock_OutHead
    {
        public T_Stock_OutHead Head { get; set; }
        public List<T_Stock_OutItems> Items { get; set; }

    }
    public class T_Stock_OutHead
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime CreateTime { get; set; }
        public decimal TotalMoney { get; set; }
        public int CustomerId { get; set; }
        public T_Base_Customer Customer { get; set; }
    }

    public class T_Stock_OutItems
    {
        public int Id { get; set; }
        public int HeadId { get; set; }
        public int BookId { get; set; }
        public int Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal Price { get; set; }
        public T_Base_Book Book { get; set; }
        public T_Stock_OutHead Head { get; set; }
    }
}

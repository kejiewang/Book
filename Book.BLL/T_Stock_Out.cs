using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BLL
{
    public class T_Stock_Out
    {
        public Book.DAL.T_Stock_Out dal = new DAL.T_Stock_Out();

        public List<Book.Model.T_Stock_Out> GetList(int CurrentPage, int PageSize, String search = "")
        {
            return dal.GetList(CurrentPage, PageSize, search);
        }

        public Book.Model.T_Stock_Out GetModel(int HeadId)
        {

            return dal.GetModel(HeadId);
        }

        public int Count(String search = "")
        {
            return dal.Count(search);
        }

        public int Delete(string[] ids)
        {
            //防止注入式漏洞
            string idstring = string.Join(", ", ids);
            return dal.Delete(idstring);
        }

        public bool Add(Model.T_Stock_Out inStock)
        {
            //throw new NotImplementedException();
            decimal totalMoney = 0;
            foreach (Book.Model.T_Stock_OutItems item in inStock.Items)
            {
                totalMoney += item.Amount * item.Discount * item.Price;
            }
            inStock.Head.TotalMoney = totalMoney;
            return dal.Add(inStock);
        }

        public Book.Model.T_Stock_OutHead GetHead(int Id)
        {
            return dal.GetHead(Id);
        }
    }
}

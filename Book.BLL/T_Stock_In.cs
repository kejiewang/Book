using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Book.BLL
{
    public class T_Stock_In
    {
        public Book.DAL.T_Stock_In dal = new DAL.T_Stock_In();
        public List<Book.Model.T_Stock_In> GetList(int CurrentPage, int PageSize)
        {
            return dal.GetList(CurrentPage, PageSize);
        }

        public Book.Model.T_Stock_In GetModel(int HeadId)
        {

            return dal.GetModel(HeadId);
        }

        public int Count()
        {

            return dal.Count();
        }

        public int Delete(string[] ids)
        {
            //防止注入式漏洞
            string idstring = string.Join(", ", ids);
            return dal.Delete(idstring);
        }

        public bool Add(Model.T_Stock_In inStock)
        {
            //throw new NotImplementedException();
            decimal totalMoney = 0;
            foreach (Book.Model.T_Stock_InItems item in inStock.Items)
            {
                totalMoney += item.Amount * item.Discount * item.Price;
            }
            inStock.Head.TotalMoney = totalMoney;
            return dal.Add(inStock);
        }
    }
}

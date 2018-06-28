using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Book.BLL
{
    public class T_Stock_In
    {
        public Book.DAL.T_Stock_In dal = new DAL.T_Stock_In();
        public List<Book.Model.T_Stock_In> GetList(int CurrentPage, int PageSize,String search = "")
        {
            return dal.GetList(CurrentPage, PageSize,search);
        }

        public Book.Model.T_Stock_In GetModel(int HeadId)
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

        public Book.Model.T_Stock_InHead GetHead(int Id)
        {

            return dal.GetHead(Id);
        }
    }
}

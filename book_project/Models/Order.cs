using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book_project.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int NoOfBooks { get; set; }
        public double Price { get; set; }
        public string CouponCode { get; set; }
        public Order()
        {

        }
        public Order(int id,int uid,int nob,double price,string cc)
        {
            OrderId = id;
            UserId = uid;
            NoOfBooks = nob;
            Price = price;
            CouponCode = cc;
        }
    }
}
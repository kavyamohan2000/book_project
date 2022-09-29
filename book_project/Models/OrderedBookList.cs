using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book_project.Models
{
    public class OrderedBookList
    {
        public int BookId { get; set; }
        public int OrderId { get; set; }
        public OrderedBookList()
        {

        }
        public OrderedBookList(int bid,int oid)
        {
            BookId = bid;
            OrderId = oid;
        }
    }
}
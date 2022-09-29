using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book_project.Models
{
    public class WishList
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public WishList()
        {

        }
        public WishList(int bid,int uid)
        {
            BookId = bid;
            UserId = uid;
        }
    }
}
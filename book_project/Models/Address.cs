using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book_project.Models
{
    public class Address
    {
        public int UserId { get; set; }
        public string UserAddress { get; set; }
        public Address()
        {

        }
        public Address(int id,string adrs)
        {
            UserId = id;
            UserAddress = adrs;
        }
    }
}
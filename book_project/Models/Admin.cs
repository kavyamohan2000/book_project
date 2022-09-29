using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book_project.Models
{
    public class Admin
    {
        public string Adminid { get; set; }
        public string Password { get; set; }
        public Admin()
        {

        }
        public Admin(string id,string pwd)
        {
            Adminid = id;
            Password = pwd;
        }
        
    }
}
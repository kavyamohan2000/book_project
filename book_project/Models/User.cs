using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book_project.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Password { get; set; }

        public string Status { get; set; }
        public string Name { get; set; }
        public User()
        {

        }
        public User(int id,string password,string status,string name)
        {
            UserId = id;
            Password = password;
            Status = status;
            Name = name;
        }

    }
    
}
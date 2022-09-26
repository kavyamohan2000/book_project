using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book_project.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Status { get; set; }
        public string Position { get; set; }
        //public DateTime CreatedAt { get; set; }
        public Category()
        {

        }
        public Category(int id,string name,string desc,string img,int sts,string pos)
        {
            CategoryId = id;
            CategoryName = name;
            Description = desc;
            Image = img;
            Status = sts;
            Position = pos;
            //CreatedAt = createdat;
        }
    }
}
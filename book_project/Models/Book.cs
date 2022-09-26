using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book_project.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }
        public Book()
        {

        }
        public Book(int id,int catid,string name,string isbn,int year,double price,string description,string position,string sts,string img)
        {
            BookId = id;
            CategoryId = catid;
            Title = name;
            ISBN = isbn;
            Year = year;
            Price = price;
            Description = description;
            Position = position;
            Status = sts;
            Image = img;

        }
    }
}
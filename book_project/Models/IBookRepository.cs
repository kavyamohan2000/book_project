using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_project.Models
{
    internal interface IBookRepository
    {
        List<Book> GetAll();
        Book GetByTitle(string title);
        Book GetByISBN(string ISBN);
        List<Book> GetByCategory(int catid);
        Book AddBook(Book book);
        void DeleteBook(int bookid);
        void UpdateBook(Book book);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using book_project.Models;

namespace book_project.Controllers
{
    public class BookController : ApiController
    {
        private IBookRepository brepository;
        public BookController()
        {
            brepository = new BookSqlImpl();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = brepository.GetAll();
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get(string title)
        {
            var data = brepository.GetByTitle(title);
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get(int catid)
        {
            var data = brepository.GetByCategory(catid);
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get1(string ISBN)
        {
            var data = brepository.GetByISBN(ISBN);
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Post(Book book)
        {
            var data = brepository.AddBook(book);
            return Ok(data);

        }
        [HttpPut]
        public IHttpActionResult Update(Book book)
        {
            brepository.UpdateBook(book);
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            brepository.DeleteBook(id);
            return Ok();
        }

    }
}
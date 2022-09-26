using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using book_project.Models;

namespace book_project.Controllers
{
    public class CategoryController : ApiController
    {
        private ICategoryRepository crepository;
        public CategoryController()
        {
            crepository = new CategorySqlImpl();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = crepository.GetAllCategories();
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get(string catname)
        {
            var data = crepository.GetByName(catname);
            if (data == null)
                return NotFound();
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Post(Category cat)
        {
            var data = crepository.AddCategory(cat);
            return Ok(data);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            crepository.DeleteCategory(id);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(Category cat)
        {
            crepository.UpdateCategory(cat);
            return Ok();
        }
    }
}
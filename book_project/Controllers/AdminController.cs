using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using book_project.Models;

namespace book_project.Models
{
    
    public class AdminController : ApiController
    {
        private IAdminRepositoy arepository;
        public AdminController()
        {
            arepository = new AdminSqlImpl();
        }
        [HttpGet]
        public IHttpActionResult Get(string id,string pswd)
        {
            var data = arepository.AdminLogin(id, pswd);
            return Ok(data);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            arepository.RemoveUser(id);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(int id)
        {
            arepository.ActivateUser(id);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Post(int did)
        {
            arepository.DeactivateUser(did);
            return Ok();
        }


    }
}
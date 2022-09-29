using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using book_project.Models;


namespace book_project.Controllers
{
    public class RegisterController : ApiController
    {
        private IUserRepository rrepository;
        public RegisterController()
        {
            rrepository = new UserSqlImpl();
        }

        [HttpPost]
        public IHttpActionResult Post(User user)
        {
            var data = rrepository.RegisterUser(user);
            return Ok(data);
        }

    }
}
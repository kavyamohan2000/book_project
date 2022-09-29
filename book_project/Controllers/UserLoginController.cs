using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using book_project.Models;

namespace book_project.Controllers
{
    public class UserLoginController : ApiController
    {
        private IUserRepository ulrepository;
        public UserLoginController()
        {
            ulrepository = new UserSqlImpl();
        }
        [HttpGet]
        public IHttpActionResult Get(int id,string pwd)
        {
            var data = ulrepository.GetLogin(id,pwd);
            return Ok(data);
        }
    }
}
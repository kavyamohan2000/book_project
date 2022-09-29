using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using book_project.Models;

namespace book_project.Controllers
{
    public class UserController : ApiController
    {
        private IUserRepository urepository;
        public UserController()
        {
            urepository = new UserSqlImpl();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = urepository.GetAll();
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = urepository.GetById(id);
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult GetWishList(int uid)
        {
            var data = urepository.ViewWishList(uid);
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult GetCart(int userid)
        {
            var data = urepository.ViewCart(userid);
            return Ok(data);
        }
        
        [HttpPost]
        public IHttpActionResult Post(int uid,int bid)
        {
             urepository.AddToWishList( uid,  bid);

            return Ok();
        }
        [HttpPost]
        public IHttpActionResult PostCart(int userid,int bookid)
        {
            urepository.AddToCart(userid, bookid);
            return Ok();
        }
        
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using book_project.Models;

namespace book_project.Controllers
{
    public class OrderController : ApiController
    {
        private IOrderRepository orepository;
        public OrderController()
        {
            orepository = new OrderSqlImpl();
        }
        [HttpGet]
        public IHttpActionResult Get(int uid)
        {
            var data = orepository.GetByUserId(uid);
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get2(int oid)
        {
            var data = orepository.TotalPrice(oid);
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult GetOrder(int orderid)
        {
            var data = orepository.ViewOrder(orderid);
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Post(Order order)
        {
            var data = orepository.MakeOrder(order);
            return Ok(data);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int oid)
        {
            orepository.DeleteOrder(oid);
            return Ok();
        }
    }
}
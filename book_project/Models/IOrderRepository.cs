using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_project.Models
{
    internal interface IOrderRepository
    {
        List<Order> GetByUserId(int uid);
        Order MakeOrder(Order order);
        void DeleteOrder(int oid);
        double TotalPrice(int oid);
        List<Book> ViewOrder(int oid);
    }
}

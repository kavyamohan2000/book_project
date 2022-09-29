using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_project.Models
{
    internal interface IUserRepository
    {
         User RegisterUser(User user);
        
        List<User> GetAll();
        User GetById(int id);
        
        void AddToWishList(int uid,int bid);
       List<Book> ViewWishList(int id);
        void AddToCart(int uid, int bid);
        List<Book> ViewCart(int id);
        User GetLogin(int id, string password);


    }
}

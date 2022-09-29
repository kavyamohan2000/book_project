using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using book_project.Models;

namespace book_project.Models
{
    internal interface IAdminRepositoy
    {
        Admin AdminLogin(string id, string pwd);
        void RemoveUser(int id);
        void ActivateUser(int id);
        void DeactivateUser(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_project.Models
{
    internal interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetByName(string catname);
        Category AddCategory(Category cat);
        void DeleteCategory(int id);
        void UpdateCategory(Category category);
    }
}

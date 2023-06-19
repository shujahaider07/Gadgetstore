using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface ICategory
    {


        public Task<IEnumerable<Category>> ListCategory();
        public Task<Category> AddCategory(Category e);
        public Task<IEnumerable<Category>> EditCategory(Category e);
        public Task<Category> GetIdByCategory(int id);

        public void deleteCategory(int id);
    }
}

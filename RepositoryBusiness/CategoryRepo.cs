using DbContextForApplicationLayer;
using Entities;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace RepositoryBusiness
{

    public class CategoryRepo : ICategory
    {

        private readonly ApplicationDbContext _db;

        public CategoryRepo(ApplicationDbContext _db )
        {
            this._db = _db;
        }

        public async Task<Category> AddCategory(Category e)
        {
            try
            {

                Category cat = new Category();
                cat.Category_Name = e.Category_Name;
                cat.Category_Type = e.Category_Type;
              


                var add = _db.Categories.Add(cat);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            return e;
        }

        public void deleteCategory(int id)
        {
            var del = _db.Categories.Find(id);
            if (del != null)
            {
                _db.Remove(del);
            }
        }

        public async Task<IEnumerable<Category>> EditCategory(Category e)
        {
            var ID = _db.Categories.Where(x => x.Category_id == e.Category_id).AsEnumerable().FirstOrDefault();

            if (ID != null)
            {
                ID.Category_Name = e.Category_Name;
                ID.Category_Type = e.Category_Type;
               

                _db.Entry(ID).State = EntityState.Modified;
                _db.SaveChangesAsync();
            }

            return null;
        }

        public async Task<Category> GetIdByCategory(int id)
        {
            return await _db.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> ListCategory()
        {
            return _db.Categories.ToList();
        }
    }
}

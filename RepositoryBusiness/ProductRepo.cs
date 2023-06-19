using DbContextForApplicationLayer;
using Entities;
using EntitiesViewModels;
using IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryBusiness
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext _db;

        public ProductRepo(ApplicationDbContext _db)
        {
            this._db = _db;
        }
        public async Task<Products> AddProducts(Products e)
        {
            try
            {

                Products pro = new Products();
                
                pro.Product_Name = e.Product_Name;
                pro.Category_Id = e.Category_Id;
               

                var add = _db.product.Add(pro);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            return e;

        }

        public void deleteProducts(int id)
        {
            var del = _db.product.Find(id);
            if (del != null)
            {
                _db.Remove(del);
            }
        }

        public Task<IEnumerable<Products>> EditProducts(Products e)
        {
            var ID = _db.product.Where(x => x.ProductId == e.ProductId).AsEnumerable().FirstOrDefault();

            if (ID != null)
            {
                ID.Product_Name = e.Product_Name;
                ID.Category_Id = e.Category_Id;
                

                _db.Entry(ID).State = EntityState.Modified;
                _db.SaveChangesAsync();
            }

            return null;
        }

        public async Task<Products> GetIdByProducts(int id)
        {
            return await _db.product.FindAsync(id);
        }

        public async Task<IEnumerable<Products>> ListProducts()
        {
            return _db.product.ToList();
        }

        public async Task<IEnumerable<productListVm>> ListProductsVm()
        {
            return _db.ProductVM.FromSqlRaw($"exec sp_bindCategoryInproductTbl");
        }

       
    }
}

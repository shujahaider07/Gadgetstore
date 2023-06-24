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
        private readonly ApplicationDbContext _dbContext;

        public ProductRepo(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public void Add(Products product)
        {
            try
            {
                _dbContext.product.Add(product);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Delete(int id)
        {
            var product = _dbContext.product.Find(id);
            if (product != null)
            {
                _dbContext.product.Remove(product);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<productListVm> GetAll()
        {
            try
            {
                List<productListVm> p1 = (from p in _dbContext.product
                                          join c in _dbContext.Categories on p.Category_Id equals c.Category_id
                                          select new productListVm
                                          {
                                              ProductId = p.ProductId,
                                              Product_Name = p.Product_Name,
                                              Category_Name = c.Category_Name
                                          }).ToList();


                return p1;

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public Products GetById(int id)
        {
            try
            {
                return _dbContext.product.Find(id);

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Update(Products product)
        {
            try
            {
                _dbContext.product.Update(product);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
          
        }


        //public List<productListVm> ListProductsVm()
        //{

        //    List<productListVm> p1 = (from p in _db.product
        //                              join c in _db.Categories on p.Category_Id equals c.Category_id
        //                              select new productListVm
        //                              {
        //                                  ProductId = p.ProductId,
        //                                  Product_Name = p.Product_Name,
        //                                  Category_Name = c.Category_Name
        //                              }).ToList();


        //    return p1;



        //}


    }
}

using Entities;
using EntitiesViewModels;

namespace IRepository
{
    public interface IProductRepo
    {
        public Task<IEnumerable<Products>> ListProducts();
        public Task<IEnumerable<productListVm>> ListProductsVm();
        public Task<Products> AddProducts(Products e);
        public Task<IEnumerable<Products>> EditProducts(Products e);
        public Task<Products> GetIdByProducts(int id);

        public void deleteProducts(int id);


    }
}

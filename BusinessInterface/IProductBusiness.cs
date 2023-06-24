using Entities;
using EntitiesViewModels;

namespace BusinessInterface
{
    public interface IProductBusiness
    {

        public Task<IEnumerable<Response>> ListProducts();
        //public Task<IEnumerable<productListVm>> ListProductsVm();
        public Task<Response> AddProducts(Products e);
        public Task<IEnumerable<Response>> EditProducts(Products e);
        public Task<Response> GetIdByProducts(int id);

        public void deleteProducts(int id);
    }
}
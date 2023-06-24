using Entities;
using EntitiesViewModels;

namespace Gadgetstore.BusinessInterface
{
    public interface IproductBusiness
    {
        IEnumerable<productListVm> GetAllProducts();
        Products GetProductById(int id);
        void AddProduct(Products product);
        void UpdateProduct(Products product);
        void DeleteProduct(int id);
    }
}

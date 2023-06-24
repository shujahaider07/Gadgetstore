using Entities;
using EntitiesViewModels;
using Gadgetstore.BusinessInterface;
using IRepository;

namespace Gadgetstore.BusinessLayer
{
    public class ProductBusiness : IproductBusiness
    {
       
        private readonly IProductRepo IProductRepo;
       
        public ProductBusiness(IProductRepo IProductRepo)
        {
            this.IProductRepo = IProductRepo;
        }

        public IEnumerable<productListVm> GetAllProducts()
        {
            return IProductRepo.GetAll();
        }

        public Products GetProductById(int id)
        {
            return IProductRepo.GetById(id);
        }

        public void AddProduct(Products product)
        {
            IProductRepo.Add(product);
        }

        public void UpdateProduct(Products product)
        {
            IProductRepo.Update(product);
        }

        public void DeleteProduct(int id)
        {
            IProductRepo.Delete(id);
        }
    }
}

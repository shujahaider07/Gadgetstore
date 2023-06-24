using Entities;
using EntitiesViewModels;

namespace IRepository
{
    public interface IProductRepo
    {
        IEnumerable<productListVm> GetAll();
        Products GetById(int id);
        void Add(Products product);
        void Update(Products product);
        void Delete(int id);


    }
}

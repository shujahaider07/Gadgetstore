using Entities;
using EntitiesViewModels;

namespace IRepository
{
    public interface ICustomer
    {

        public Task<IEnumerable<Customer>> ListCustomer();
        public Task<Customer> AddCustomer(CustomerVM customerVM);
        public Task<IEnumerable<Customer>> EditCustomer(Customer e);
        public Task<Customer> GetIdByCustomer(int id);

        public void deleteCustomer(int id);

    }
}
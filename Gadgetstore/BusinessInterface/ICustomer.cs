using Entities;
using EntitiesViewModels;

namespace Gadgetstore.BusinessInterface
{
    public interface ICustomer
    {
        public void AddCustomer(CustomerVM customervm);
        public void UpdateCustomer(Customer customer);
        public void DeleteCustomer(int id);
        public IEnumerable<Customer> GetAllCustomer();
        public Customer GetAllCustomerById(int id);

    }
}

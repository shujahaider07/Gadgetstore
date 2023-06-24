using Entities;
using EntitiesViewModels;

namespace IRepository
{
    public interface ICustomerRepo
    {
        public void AddCustomer(CustomerVM customerVM);
        public void UpdateCustomer(Customer customer);
        public void DeleteCustomer(int id);
        public Customer CustomerGetById(int id);
        public IEnumerable<Customer> GetAllCustomers();
    }
}

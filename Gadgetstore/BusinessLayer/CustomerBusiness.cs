using Entities;
using EntitiesViewModels;
using Gadgetstore.BusinessInterface;
using IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gadgetstore.BusinessLayer
{
    public class CustomerBusiness : ICustomer
    {
        private readonly ICustomerRepo _Customer;

        public CustomerBusiness(ICustomerRepo _Customer)
        {
            this._Customer = _Customer;
        }
        public void AddCustomer(CustomerVM customer)
        {
            try
            {
               

                _Customer.AddCustomer(customer);
            }

            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteCustomer(int id)
        {
            try
            {
                _Customer.DeleteCustomer(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            try
            {
              return  _Customer.GetAllCustomers();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Customer GetAllCustomerById(int id)
        {
            try
            {

               return _Customer.CustomerGetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {
                _Customer.UpdateCustomer(customer);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

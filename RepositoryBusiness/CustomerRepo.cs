using DbContextForApplicationLayer;
using Entities;
using EntitiesViewModels;
using IRepository;

namespace RepositoryBusiness
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ApplicationDbContext _db;
        public CustomerRepo(ApplicationDbContext db)
        {
            this._db = db;
        }

        public void AddCustomer(CustomerVM customerVM)
        {

            using (var ExceptionDb = _db.Database.BeginTransaction())
            {
                try
                {
                    var add = _db.Customers.Add(new Customer
                    {

                        Age = customerVM.Age,
                        contact = customerVM.contact,
                        Email = customerVM.Email,
                        First_Name = customerVM.First_Name,
                        gender = customerVM.gender,
                        Last_Name = customerVM.Last_Name,

                    });
                    _db.SaveChanges();

                    ExceptionDb.CommitAsync();

                }


                catch (Exception)
                {
                    ExceptionDb.RollbackAsync();
                    throw;
                }


            }
        }




        public Customer CustomerGetById(int id)
        {
            try
            {
                return _db.Customers.Find(id);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void DeleteCustomer(int id)
        {
            var del = _db.Customers.Find(id);
            _db.Remove(del);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _db.Customers.OrderByDescending(x => x.Id).ToList();
        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {

                _db.Customers.Update(customer);
                _db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
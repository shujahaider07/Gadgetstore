using DbContextForApplicationLayer;
using Entities;
using EntitiesViewModels;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace RepositoryBusiness
{
    public class CustomerRepo : ICustomer
    {
        private readonly ApplicationDbContext _db;
        public CustomerRepo(ApplicationDbContext db)
        {
            this._db = db;
        }

        public async Task<Customer> AddCustomer(CustomerVM customerVM)
        {
            Customer c = new Customer();


            _db.Customers.Add(new Customer
            {
                First_Name = customerVM.First_Name,
                Last_Name = customerVM.Last_Name,
                Age = customerVM.Age,
                contact = customerVM.contact,
                gender = customerVM.gender,
                Email = customerVM.Email,


            });



                var add = _db.Customers.Add(c);
                _db.SaveChanges();



            return c;

        }

        public void deleteCustomer(int id)
        {
            var del = _db.Customers.Find(id);
            if (del != null)
            {
                _db.Remove(del);
            }
        }

        public Task<IEnumerable<Customer>> EditCustomer(Customer e)
        {
            var ID = _db.Customers.Where(x => x.Id == e.Id).AsEnumerable().FirstOrDefault();

            if (ID != null)
            {
                ID.First_Name = e.First_Name;
                ID.gender = e.gender;
                ID.Last_Name = e.Last_Name;
                
                ID.Email = e.Email;
                ID.contact = e.contact;
                ID.Age = e.Age;


                _db.Entry(ID).State = EntityState.Modified;
                _db.SaveChangesAsync();
            }

            return null;
        }

        public async Task<Customer> GetIdByCustomer(int id)
        {
            return await _db.Customers.FindAsync(id);
        }

        public  async Task<IEnumerable<Customer>> ListCustomer()
        {
            return _db.Customers.ToList();
        }
    }
}
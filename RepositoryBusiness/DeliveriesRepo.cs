using DbContextForApplicationLayer;
using Entities;
using EntitiesViewModels;
using IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryBusiness
{
    public class DeliveriesRepo : IDeliveries
    {

        private readonly ApplicationDbContext _db;

        public DeliveriesRepo(ApplicationDbContext _db)
        {
            this._db = _db;
        }



        public async Task<Deliveries> AddDeliveries(Deliveries e)
        {
            try
            {

                Deliveries del = new Deliveries();
                del.Customer_id= e.Customer_id;
                del.Date = DateTime.Now;



                var add = _db.Delivery.Add(del);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            return e;
        }

        public void deleteDeliveries(int id)
        {
            var del = _db.Delivery.Find(id);
            if (del != null)
            {
                _db.Remove(del);
            }
        }

        public Task<IEnumerable<Deliveries>> EditDeliveries(Deliveries e)
        {
            var ID = _db.Delivery.Where(x => x.Deliveries_id == e.Deliveries_id).AsEnumerable().FirstOrDefault();

            if (ID != null)
            {
                ID.Customer_id = e.Customer_id;
                ID.Date = DateTime.Now;


                _db.Entry(ID).State = EntityState.Modified;
                _db.SaveChangesAsync();
            }

            return null;
        }

        public async Task<Deliveries> GetIdByDeliveries(int id)
        {
            return await _db.Delivery.FindAsync(id);
        }

        public async Task<IEnumerable<Deliveries>> ListDeliveries()
        {
            return _db.Delivery.ToList();
        }

        public async Task<IEnumerable<CustomerNameVm>> ListDeliveriesVm()
        {
            return _db.CustomersNameVm.FromSqlRaw($"exec sp_CustomerNameInDelivery");
        }
    }
}

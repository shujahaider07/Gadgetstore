using Entities;
using EntitiesViewModels;

namespace IRepository
{
    public interface IDeliveries
    {

        public Task<IEnumerable<Deliveries>> ListDeliveries();
        public Task<IEnumerable<CustomerNameVm>> ListDeliveriesVm();
        public Task<Deliveries> AddDeliveries(Deliveries e);
        public Task<IEnumerable<Deliveries>> EditDeliveries(Deliveries e);
        public Task<Deliveries> GetIdByDeliveries(int id);

        public void deleteDeliveries(int id);

        

    }
}

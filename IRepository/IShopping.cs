using Entities;
using EntitiesViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IShopping
    {
        public Task<IEnumerable<Shopping>> ListShopping();
        public Task<IEnumerable<ShoppingVm>> ListShoppingVm();
        public Task<Shopping> AddShopping(Shopping e);
        public Task<IEnumerable<Shopping>> EditShopping(Shopping e);
        public Task<Shopping> GetIdByShopping(int id);

        public void deleteShopping(int id);
    }
}

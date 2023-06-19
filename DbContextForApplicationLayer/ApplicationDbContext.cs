using Entities;
using EntitiesViewModels;
using Microsoft.EntityFrameworkCore;

namespace DbContextForApplicationLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }



        public DbSet<Customer> Customers { get; set; }
        public DbSet<Products> product { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Deliveries> Delivery { get; set; }
        public DbSet<Shopping> Shoppings { get; set; }


        //ViewModels

        public DbSet<productListVm> ProductVM { get; set; }
        public DbSet<CustomerNameVm> CustomersNameVm { get; set; }
        public DbSet<ShoppingVm> ShoppingVms { get; set; }



        //HAsnoKey
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<productListVm>(e => e.HasNoKey());
            modelBuilder.Entity<CustomerNameVm>(e => e.HasNoKey());
            modelBuilder.Entity<ShoppingVm>(e => e.HasNoKey());
            modelBuilder.Entity<CustomerVM>(e => e.HasNoKey());

        }

    }
}
using NorthWindDb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDb
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base(connection)
        {

        }

        static readonly string connection = ConfigurationManager.ConnectionStrings["NorthWindDbCs"].ConnectionString;
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Territory> Territories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Shipper> Shippers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderDetailConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new CustomerDemographicConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new TerritoryConfiguration());
            modelBuilder.Configurations.Add(new SupplierConfiguration());
            modelBuilder.Configurations.Add(new RegionConfiguration());
            modelBuilder.Configurations.Add(new ShipperConfiguration());

            base.OnModelCreating(modelBuilder);
        }


    }
}

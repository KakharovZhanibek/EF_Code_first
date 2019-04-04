using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDb.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ? ShippedDate { get; set; }
        public int ShipVia { get; set; }
        public decimal Fright { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }

    public class OrderConfiguration: EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            HasKey(p => p.Id);
            HasMany(p => p.OrderDetails)
                .WithRequired()
                .HasForeignKey(p => p.OrderId);
        }
    }
}

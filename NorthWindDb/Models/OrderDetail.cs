using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDb.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }

        public byte [] RowVersion { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
    public class OrderDetailConfiguration : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailConfiguration()
        {
            HasKey(p => new
            {
                p.OrderId,
                p.ProductId
            });
            Property(p => p.OrderId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.ProductId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.UnitPrice).HasColumnType("money").IsRequired();
            Property(p => p.Quantity).IsRequired();
            Property(p => p.Discount).IsRequired();

            Property(p => p.RowVersion).IsConcurrencyToken();
            Property(p => p.RowVersion).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}

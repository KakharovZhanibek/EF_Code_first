using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDb.Models
{
    /*
    public class AnotherOrderInfo
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        [Timestamp]
        public byte [] RowVersion { get; set; }
    }

    public class AnotherContext : DbContext
    {
        public DbSet<AnotherOrderInfo> AnotherOrderInfos { get; set; }
        static readonly string connection = ConfigurationManager.ConnectionStrings["AnotherDbConnection"].ConnectionString;

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnotherOrderInfo>()
                .Property(p => p.RowVersion)
                .IsConcurrencyToken();

            base.OnModelCreating(modelBuilder);
        }
        public AnotherContext() : base(connection)
        {

        }
    }*/
}

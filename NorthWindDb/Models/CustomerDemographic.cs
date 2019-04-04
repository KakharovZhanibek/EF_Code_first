using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDb.Models
{
    public class CustomerDemographic
    {
        public string CustomerTypeId { get; set; }
        public string CustomerDesc { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
    public class CustomerDemographicConfiguration:EntityTypeConfiguration<CustomerDemographic>
    {
        public CustomerDemographicConfiguration()
        {
            HasKey(p => p.CustomerTypeId);
        }
    }
}

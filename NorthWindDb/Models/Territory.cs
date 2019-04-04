using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDb.Models
{
    public class Territory
    {
        public string TerritoryId { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionId { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
    public class TerritoryConfiguration : EntityTypeConfiguration<Territory>
    {
        public TerritoryConfiguration()
        {
            HasKey(p => p.TerritoryId);
            Property(p => p.TerritoryDescription).IsRequired();
        }
    }
}

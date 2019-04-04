using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDb.Models
{
    public class Region
    {
        public int RegionId { get; set; }
        public string RegionDescription { get; set;}

        public virtual ICollection<Territory> Territories { get; set; }
    }
    public class RegionConfiguration:EntityTypeConfiguration<Region>
    {
        public RegionConfiguration()
        {
            HasKey(p => p.RegionId);
            HasMany(p => p.Territories).WithRequired().HasForeignKey(p => p.RegionId);
            Property(p => p.RegionDescription)
                .IsRequired();
        }
    }
}

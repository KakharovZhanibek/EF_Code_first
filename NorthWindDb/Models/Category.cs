using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDb.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public string PicturePath { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            HasKey(p => p.CategoryId);
            HasMany(p => p.Products)
                .WithRequired().HasForeignKey(p => p.CategoryId);

            Property(p => p.CategoryName).IsRequired();
            Property(p => p.PicturePath).HasColumnName("image");
        }
    }
}

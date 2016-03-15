using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eddyt.Blog.Core.Domain;

namespace Eddyt.Blog.Data.Mapping
{
    public class CategoryMap:EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name).HasMaxLength(100).IsRequired();

            // Table & Column Mappings
            this.ToTable("Category");
            this.Property(t => t.Name).HasColumnName("Name");

            // 关系
        }
    }
}

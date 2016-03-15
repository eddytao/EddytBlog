using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eddyt.Blog.Core.Domain;

namespace Eddyt.Blog.Data.Mapping
{
    public class PostMap : EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            // 主键
            this.HasKey(t => t.Id);

            // 字段
            this.Property(t => t.PostNo).IsRequired();
            this.Property(t => t.Title).HasMaxLength(500).IsRequired();
            this.Property(t => t.Content).IsMaxLength().IsRequired();
            this.Property(t => t.Author).HasMaxLength(50).IsRequired();

            // 表名和列名映射
            this.ToTable("Post");

            // 关系
            this.HasMany(t => t.Tags);
            this.HasMany(t => t.Categories);
            this.HasMany(t => t.Comments);
        }
    }
}

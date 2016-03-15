using Eddyt.Blog.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eddyt.Blog.Data.Mapping
{
    public class PostCategoryMap : EntityTypeConfiguration<PostCategory>
    {
        public PostCategoryMap()
        {
            // 主键
            this.HasKey(t => t.Id);

            // 字段
            this.Property(t => t.PostId).IsRequired();
            this.Property(t => t.CategoryId).HasMaxLength(200).IsRequired();
            // 表名和列名映射
            this.ToTable("PostCategory");

            // 关系
            this.HasRequired(t => t.Category).WithMany().HasForeignKey(t => t.CategoryId);
        }
    }
}

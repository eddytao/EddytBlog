using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eddyt.Blog.Core.Domain;

namespace Eddyt.Blog.Data.Mapping
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            // 主键
            this.HasKey(t => t.Id);

            // 字段
            this.Property(t => t.Name).HasMaxLength(100).IsRequired();
            this.Property(t => t.Content).HasMaxLength(500).IsRequired();
            this.Property(t => t.Email).HasMaxLength(50).IsRequired();

            // 表名和列名映射
            this.ToTable("Comment");

            // 关系
            this.HasMany(t => t.ReplyComments);
            this.HasRequired(t=>t.Post).WithMany(t=>t.Comments);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eddyt.Blog.Core.Domain;

namespace Eddyt.Blog.Data.Mapping
{
    public class TagMap : EntityTypeConfiguration<Tag>
    {
        public TagMap()
        {
            // 主键
            this.HasKey(t => t.Id);

            // 字段
            this.Property(t => t.PostId).HasMaxLength(200).IsRequired();
            this.Property(t => t.Name).HasMaxLength(200).IsRequired();
            // 表名和列名映射
            this.ToTable("Tag");

            // 关系
        }


    }
}

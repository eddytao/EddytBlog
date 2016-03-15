using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eddyt.Blog.Core.Domain
{
    public class Post:BaseEntity
    {
        public Post() 
        {
            this.Categories=new List<Category>();
            this.Tags=new List<Tag>();
            this.Comments=new List<Comment>();
            this.CreateTime = DateTime.Now;
            this.UpateTime = DateTime.Now;
        }

        #region 属性
        public int PostNo { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int? ViewCount { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpateTime { get; set; }

        #endregion

        #region 关系
        public virtual IList<Category> Categories { get; set; }
        public virtual IList<Tag> Tags { get; set; }
        public virtual IList<Comment> Comments { get; set; }

        #endregion

        #region 方法

        #endregion
    }
}

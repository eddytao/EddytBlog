using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eddyt.Blog.Core.Domain
{
    public class Comment:BaseEntity
    {
        public Comment()
        {
            this.ReplyComments=new List<Comment>();
            this.CreateTime = DateTime.Now;
        }

        #region 属性
        public string PostId { get; set; }
        public string ReplyCommentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }

        #endregion

        #region 关系
        public virtual IList<Comment> ReplyComments { get; set; }
        public virtual Post Post { get; set; }

        #endregion
    }
}

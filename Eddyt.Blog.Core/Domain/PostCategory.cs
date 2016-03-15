using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eddyt.Blog.Core.Domain
{
    public class PostCategory:BaseEntity
    {
        public PostCategory()
        {
            this.Category=new Category();
        }

        #region 属性
        public string PostId { get; set; }
        public string CategoryId { get; set; }

        #endregion

        #region 关系

        public virtual Category Category { get; set; }

        #endregion
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eddyt.Blog.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public string CommentId { get; set; }
        public string ArticleId { get; set; }
        public string ReplyCommentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public System.DateTime CreateTime { get; set; }
    
        public virtual Article Article { get; set; }
    }
}

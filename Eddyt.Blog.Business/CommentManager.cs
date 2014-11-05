using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eddyt.Blog.Data;

namespace Eddyt.Blog.Business
{
    public class CommentManager
    {
        private readonly EddytBlogEntities db = new EddytBlogEntities();

        public IEnumerable<Comment> GetAllCommentsByArticleId(string articleId)
        {
            return db.Comment.Where(c => c.ArticleId == articleId);
        }

        public IEnumerable<Comment> GetAboutComments()
        {
            return db.Comment.Where(c => c.ArticleId == null);
        }

        public void AddComment(Comment comment)
        {
            db.Comment.Add(comment);
            db.SaveChanges();
        }
    }
}

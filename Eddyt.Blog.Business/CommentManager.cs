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

        public PageResult<Comment> GetAllCommentsByPageResult(int pageNumber, int pageSize)
        {
            var result = new PageResult<Comment>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = db.Comment.Count(),
                ResultList = db.Comment.AsQueryable().OrderByDescending(c => c.CreateTime)
                                                    .Skip(pageSize * (pageNumber < 1 ? 0 : pageNumber - 1))
                                                    .Take(pageSize)
            };
            return result;
        }

        public void AddComment(Comment comment)
        {
            db.Comment.Add(comment);
            db.SaveChanges();
        }
    }
}

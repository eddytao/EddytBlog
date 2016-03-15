using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eddyt.Blog.Core.Domain;
using Eddyt.Blog.Data;
using Eddyt.Blog.Core.Data;

namespace Eddyt.Blog.Business
{
    public class CommentManager
    {
        private readonly IRepository<Comment> _commentRepository;

        public CommentManager(IRepository<Comment> commentRepository)
        {
            this._commentRepository = commentRepository;
        }

        public IEnumerable<Comment> GetAllCommentsByArticleId(string articleId)
        {
            return _commentRepository.Table.Where(c => c.PostId == articleId);
        }

        public IEnumerable<Comment> GetAboutComments()
        {
            return _commentRepository.Table.Where(c => c.PostId == null);
        }

        public PageResult<Comment> GetAllCommentsByPageResult(int pageNumber, int pageSize)
        {
            var result = new PageResult<Comment>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = _commentRepository.Table.Count(),
                ResultList = _commentRepository.Table.AsQueryable().OrderByDescending(c => c.CreateTime)
                                                    .Skip(pageSize * (pageNumber < 1 ? 0 : pageNumber - 1))
                                                    .Take(pageSize)
            };
            return result;
        }

        public void AddComment(Comment comment)
        {
            _commentRepository.Insert(comment);
        }
    }
}

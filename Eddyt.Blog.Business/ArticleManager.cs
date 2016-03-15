using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eddyt.Blog.Core;
using Eddyt.Blog.Core.Data;
using Eddyt.Blog.Core.Domain;
using Eddyt.Blog.Data;

namespace Eddyt.Blog.Business
{
    public class ArticleManager
    {
        private readonly IRepository<Post> _postRepository;

        public ArticleManager(IRepository<Post> postRepository)
        {
            this._postRepository = postRepository;
        }

        public IEnumerable<Post> GetAllArticles()
        {
            return _postRepository.Table.AsQueryable().OrderByDescending(a => a.CreateTime);
        }

        public PageResult<Post> GetAllArticlesByPageResult(int pageNumber, int pageSize)
        {
            var result = new PageResult<Post>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = _postRepository.Table.Count(),
                ResultList = _postRepository.Table.AsQueryable().OrderByDescending(a => a.CreateTime)
                                                    .Skip(pageSize * (pageNumber < 1 ? 0 : pageNumber - 1))
                                                    .Take(pageSize)
            };
            return result;
        }

        public Post GetByArticleNo(int postNo)
        {
            return _postRepository.Table.FirstOrDefault(a => a.PostNo == postNo);
        }

        public void AddArticle(Post post)
        {
            _postRepository.Insert(post); 
        }

        public void DeleteArticle(string postId)
        {
            var article = _postRepository.Table.FirstOrDefault(a => a.Id == postId);
            _postRepository.Delete(article);
        }

        public void EditArticle(Post post)
        {
            _postRepository.Update(post);
        }
    }
}

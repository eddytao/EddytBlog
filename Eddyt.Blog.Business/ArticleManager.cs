using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eddyt.Blog.Data;

namespace Eddyt.Blog.Business
{
    public class ArticleManager
    {
        private readonly EddytBlogEntities db = new EddytBlogEntities();

        public IEnumerable<Article> GetAllArticles()
        {
            return db.Article.AsQueryable().OrderByDescending(a => a.CreateTime);
        }

        public PageResult<Article> GetAllArticlesByPageResult(int pageNumber, int pageSize)
        {
            var result = new PageResult<Article>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = db.Article.Count(),
                ResultList = db.Article.AsQueryable().OrderByDescending(a => a.CreateTime)
                                                    .Skip(pageSize * (pageNumber < 1 ? 0 : pageNumber - 1))
                                                    .Take(pageSize)
            };
            return result;
        }

        public Article GetByArticleNo(int? articleNo)
        {
            return db.Article.FirstOrDefault(a => a.ArticleNo == articleNo);
        }

        public void AddArticle(Article article)
        {
            db.Article.Add(article);
            db.SaveChanges();
        }

        public void DeleteArticle(string articleId)
        {
            var article = db.Article.FirstOrDefault(a => a.ArticleId == articleId);
            db.Article.Remove(article);
            db.SaveChanges();
        }

        public void EditArticle(Article article)
        {
            db.Article.Attach(article);
            db.Entry(article).State=EntityState.Modified;
            db.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eddyt.Blog.Business;
using Eddyt.Blog.Data;
using Eddyt.Blog.Core.Domain;

namespace Eddyt.Blog.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ArticleManager articleManager = new ArticleManager(new EFRepository<Post>(new EddytBlogObjectContext("EddytBlogEntities")));
        private readonly CommentManager commentManager=new CommentManager(new EFRepository<Comment>(new EddytBlogObjectContext("EddytBlogEntities")));

        [Authorize]
        public ActionResult Index(int page = 1)
        {
            return View(articleManager.GetAllArticlesByPageResult(page, 5));
        }

        [Authorize]
        public ActionResult CommentManager(int page=1)
        {
            return View(commentManager.GetAllCommentsByPageResult(page,5));
        }

        [Authorize]
        public ActionResult Success()
        {
            return View();
        }

        [Authorize]
        public ActionResult AddArticle()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize]
        public ActionResult AddArticle(Post post)
        {
            post.PostNo = new Random().Next(100000);
            post.CreateTime = DateTime.UtcNow;   //格林威治时间
            post.Author = "admin";

            try
            {
                articleManager.AddArticle(post);
                return RedirectToAction("Success");

            }
            catch (Exception exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult DeleteArticle(string articleId)
        {
            try
            {
                articleManager.DeleteArticle(articleId);
                return RedirectToAction("Success");
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        [Authorize]
        public ActionResult EditArticle(int articleNo)
        {
            return View(articleManager.GetByArticleNo(articleNo));
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize]
        public ActionResult EditArticle(Post post)
        {
            var _article = articleManager.GetByArticleNo(post.PostNo);
            if (_article == null) throw new ArgumentNullException("_article");

            _article.Title = post.Title;
            _article.Tags = post.Tags;
            _article.Content = post.Content;
            
            try
            {
                articleManager.EditArticle(_article);
                return RedirectToAction("Success");
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
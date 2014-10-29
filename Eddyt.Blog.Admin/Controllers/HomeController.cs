using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eddyt.Blog.Business;
using Eddyt.Blog.Data;

namespace Eddyt.Blog.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ArticleManager articleManager = new ArticleManager();

        public ActionResult Index(int page = 1)
        {
            return View(articleManager.GetAllArticlesByPageResult(page, 5));
        }


        public ActionResult Success()
        {
            return View();
        }

        public ActionResult AddArticle()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddArticle(Article article)
        {
            article.ArticleId = Guid.NewGuid().ToString();
            article.ArticleNo = new Random().Next(100000);
            article.CreateTime = DateTime.Now;
            article.CreateName = "admin";

            try
            {
                articleManager.AddArticle(article);
                return RedirectToAction("Success");

            }
            catch (Exception exception)
            {

                throw;
            }
        }

        [HttpGet]
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

        public ActionResult EditArticle(int articleNo)
        {
            return View(articleManager.GetByArticleNo(articleNo));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditArticle(Article article)
        {
            var _article = articleManager.GetByArticleNo(article.ArticleNo);
            if (_article == null) throw new ArgumentNullException("_article");

            _article.Title = article.Title;
            _article.Tag = article.Tag;
            _article.Content = article.Content;
            
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
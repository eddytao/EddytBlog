using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eddyt.Blog.Business;
using Eddyt.Blog.Data;
using Eddyt.Blog.Core.Domain;

namespace Eddyt.Blog.Web.Controllers
{
    public class ArchivesController : Controller
    {
        private readonly ArticleManager articleManager=new ArticleManager(new EFRepository<Post>(new EddytBlogObjectContext("EddytBlogEntities")));
        private readonly CommentManager commentManager=new CommentManager(new EFRepository<Comment>(new EddytBlogObjectContext("EddytBlogEntities")));
        //
        // GET: /Archives/
        public ActionResult Index(int articleNo)
        {
            var article = articleManager.GetByArticleNo(articleNo);
            var comments = commentManager.GetAllCommentsByArticleId(article.Id);

            article.CreateTime.AddHours(8);       //格林威治时间转换为北京时间

            ViewBag.Comments = comments;
            ViewBag.CommentsCount = comments.Count();

            return View(article);
        }

        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            comment.Id = Guid.NewGuid().ToString();
            comment.CreateTime = DateTime.UtcNow;

            try
            {
                commentManager.AddComment(comment);
                return Redirect("~/Archives/" + HttpContext.Request.Form["ArticleNo"]);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eddyt.Blog.Business;
using Eddyt.Blog.Data;

namespace Eddyt.Blog.Web.Controllers
{
    public class ArchivesController : Controller
    {
        private readonly ArticleManager articleManager=new ArticleManager();
        private readonly CommentManager commentManager=new CommentManager();
        //
        // GET: /Archives/
        public ActionResult Index(int? articleNo)
        {
            var article = articleManager.GetByArticleNo(articleNo);
            var comments = commentManager.GetAllCommentsByArticleId(article.ArticleId);

            ViewBag.Comments = comments;
            ViewBag.CommentsCount = comments.Count();

            return View(article);
        }

        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            comment.CommentId = Guid.NewGuid().ToString();
            comment.CreateTime = DateTime.Now;

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
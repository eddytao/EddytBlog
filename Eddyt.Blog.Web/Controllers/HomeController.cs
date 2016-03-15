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
    public class HomeController : Controller
    {
        private readonly ArticleManager articleManager=new ArticleManager(new EFRepository<Post>(new EddytBlogObjectContext("EddytBlogEntities")));
        private readonly CommentManager commentManager = new CommentManager(new EFRepository<Comment>(new EddytBlogObjectContext("EddytBlogEntities")));

        public ActionResult Index(int page=1)
        {
            return View(articleManager.GetAllArticlesByPageResult(page, 3));
        }

        public ActionResult About()
        {
            ViewBag.Message = "About";

            return View(commentManager.GetAboutComments());
        }

        public ActionResult GuestBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            comment.Id = Guid.NewGuid().ToString();
            comment.CreateTime = DateTime.UtcNow;
            comment.PostId = "1";

            try
            {
                commentManager.AddComment(comment);
                return Redirect("~/Home/About");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
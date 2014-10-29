using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Eddyt.Blog.Business;

namespace Eddyt.Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ArticleManager articleManager=new ArticleManager();

        public ActionResult Index(int page=1)
        {
            return View(articleManager.GetAllArticlesByPageResult(page, 3));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GuestBook()
        {
            return View();
        }
    }
}
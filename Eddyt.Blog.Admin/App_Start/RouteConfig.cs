using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Eddyt.Blog.Admin
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "EditArticle",
                url: "EditArticle/{articleNo}",
                defaults: new { controller = "Home", action = "EditArticle", articleNo = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DeleteArticle",
                url: "DeleteArticle/{articleId}",
                defaults: new { controller = "Home", action = "DeleteArticle", articleId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Index",
                url: "page={page}",
                defaults: new { controller = "Home", action = "Index", page = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{page}",
                defaults: new { controller = "Home", action = "Index", page = UrlParameter.Optional }
            );
        }
    }
}

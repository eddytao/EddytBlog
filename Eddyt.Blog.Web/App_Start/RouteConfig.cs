using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Eddyt.Blog.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AddComment",
                url: "Archives/AddComment",
                defaults: new { controller = "Archives", action = "AddComment" }
            );

            routes.MapRoute(
                name: "AboutAddComment",
                url: "Home/AddComment",
                defaults: new { controller = "Home", action = "AddComment" }
            );

            routes.MapRoute(
                name: "Archives",
                url: "Archives/{articleNo}",
                defaults: new { controller = "Archives", action = "Index", articleNo = UrlParameter.Optional }
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

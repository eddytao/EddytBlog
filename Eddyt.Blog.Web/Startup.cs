using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Eddyt.Blog.Web.Startup))]
namespace Eddyt.Blog.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

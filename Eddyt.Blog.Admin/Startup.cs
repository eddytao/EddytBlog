using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Eddyt.Blog.Admin.Startup))]
namespace Eddyt.Blog.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

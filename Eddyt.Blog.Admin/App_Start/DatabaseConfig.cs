using Eddyt.Blog.Data;
using Eddyt.Blog.Data.Initializers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Eddyt.Blog.Admin.App_Start
{
    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EddytBlogObjectContext>());
            new EddytBlogObjectContext("DefaultConnection").Database.Initialize(true);
        }
    }
}
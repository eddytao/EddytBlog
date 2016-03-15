using Eddyt.Blog.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eddyt.Blog.Data
{
    public interface IDbContext : IObjectContextAdapter
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();

        /// <summary>
        /// 获取DbContext
        /// </summary>
        DbContext DbContext { get; }
    }
}

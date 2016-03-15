using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eddyt.Blog.Core
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
    }
}

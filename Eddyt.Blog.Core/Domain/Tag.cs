using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eddyt.Blog.Core.Domain
{
    public class Tag:BaseEntity
    {
        public string PostId { get; set; }
        public string Name { get; set; }
    }
}

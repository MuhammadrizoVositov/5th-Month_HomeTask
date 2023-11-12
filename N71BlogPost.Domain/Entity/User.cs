using N71BlogPost.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N71BlogPost.Domain.Entity
{
    public class User : IEntity
    {
        public Guid Id { get ; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAdress { get; set; }

        public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
    }
}

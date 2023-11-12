using N71BlogPost.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N71BlogPost.Domain.Entity
{
    public class Blog : IEntity
    {
        public Guid Id { get ; set ; }
        public Guid UserId { get ; set ; }
        public string Description { get ; set ; }
        public DateTime CreatedDate { get ; set ; }
        public ICollection<Comment> Comments = new List<Comment>();
    }
}

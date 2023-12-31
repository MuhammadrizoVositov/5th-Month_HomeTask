﻿using N71BlogPost.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N71BlogPost.Domain.Entity
{
    public class Comment:IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; } = default!;
        public Guid ParentId { get; set; } = default!;
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
        public DateTime CreatedDate { get; set; } = default!;
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public  User User { get; set; } = new User();
    }
}

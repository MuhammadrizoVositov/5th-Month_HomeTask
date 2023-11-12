using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N71BlogPost.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N71BlogPost.Persistence.EntityConfigurations
{
    public class UserConfuguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(user => user.Blogs)
                .WithOne()
                .HasForeignKey(b => b.UserId);
        }
    }
}

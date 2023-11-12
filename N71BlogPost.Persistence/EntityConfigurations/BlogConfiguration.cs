using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N71BlogPost.Domain.Entity;

namespace N71BlogPost.Persistence.EntityConfigurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder
            .HasMany(blog => blog.Comments)
            .WithOne()
            .HasForeignKey(comment => comment.BlogId);
    }
}

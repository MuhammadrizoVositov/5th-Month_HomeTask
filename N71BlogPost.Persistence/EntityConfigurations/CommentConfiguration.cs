using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N71BlogPost.Domain.Entity;

namespace N71BlogPost.Persistence.EntityConfigurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder
            .HasMany(comment => comment.Comments)
            .WithOne()
            .HasForeignKey(comment => comment.ParentId);
    }
}

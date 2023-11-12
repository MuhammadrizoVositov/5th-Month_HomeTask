using N71BlogPost.Domain.Entity;

namespace N71BlogPost.Persistence.Repositories.BlogRepository
{
    public interface IBlogRepository
    {
        IQueryable<Blog> Get(bool asNoTracking = true);
        ValueTask<Blog> GetByIdAsync(Guid id, bool asNoTracking = true);
        ValueTask<Blog> CreateAsync(Blog Blog, bool saveChanges = true, CancellationToken cancellationToken = default);
        ValueTask<Blog> UpdateAsync(Blog Blog, bool saveChanges = true, CancellationToken cancellationToken = default);
        ValueTask<Blog> DeleteAsync(Blog Blog, bool saveChanges = true, CancellationToken cancellationToken = default);
    }
}

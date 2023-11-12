using N71BlogPost.Application.Services;
using N71BlogPost.Domain.Entity;
using N71BlogPost.Persistence.Repositories.BlogRepository;

namespace N71BlogPost.Infrastructure.Services;

public class BlogService : IBlogService
{
    private readonly IBlogRepository _blogRepository;

    public BlogService(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public ValueTask<Blog> CreateAsync(Blog Blog, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _blogRepository.CreateAsync(Blog, saveChanges, cancellationToken);
    }

    public async ValueTask<Blog> DeleteAsync(Blog Blog, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var delete = await _blogRepository.GetByIdAsync(Blog.Id,true);
        return await _blogRepository.DeleteAsync(delete, saveChanges, cancellationToken);
    }

    public IQueryable<Blog> Get(bool asNoTracking = true)
    {
        return _blogRepository.Get(asNoTracking);
    }

    public async ValueTask<Blog> GetByIdAsync(Guid id, bool asNoTracking = true)
    {
        return await _blogRepository.GetByIdAsync(id, asNoTracking);
    }

    public async ValueTask<Blog> UpdateAsync(Blog Blog, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var update = await _blogRepository.GetByIdAsync(Blog.Id);
        update.Description = Blog.Description;
        return await _blogRepository.UpdateAsync(update, saveChanges, cancellationToken);
    }
}

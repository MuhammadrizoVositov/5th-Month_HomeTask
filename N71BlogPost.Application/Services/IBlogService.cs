using N71BlogPost.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N71BlogPost.Application.Services
{
    public interface IBlogService
    {
        IQueryable<Blog> Get(bool asNoTracking = true);
        ValueTask<Blog> GetByIdAsync(Guid id, bool asNoTracking = true);
        ValueTask<Blog> CreateAsync(Blog Blog, bool saveChanges = true, CancellationToken cancellationToken = default);
        ValueTask<Blog> UpdateAsync(Blog Blog, bool saveChanges = true, CancellationToken cancellationToken = default);
        ValueTask<Blog> DeleteAsync(Blog Blog, bool saveChanges = true, CancellationToken cancellationToken = default);
    }
}

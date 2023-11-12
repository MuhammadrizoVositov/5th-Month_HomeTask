using N71BlogPost.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N71BlogPost.Application.Services
{
    public interface IUserService
    {
        IQueryable<User> Get(bool asNoTracking = true);
        ValueTask<User> GetByIdAsync(Guid id, bool asNoTracking = true);
        ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
        ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
        ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
    }
}

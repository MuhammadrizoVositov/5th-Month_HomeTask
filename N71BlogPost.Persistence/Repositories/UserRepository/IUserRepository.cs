using N71BlogPost.Domain.Entity;

namespace N71BlogPost.Persistence.Repositories.UserRepository;

public interface IUserRepository
{
    IQueryable<User> Get(bool asNoTracking = true);
    ValueTask<User> GetByIdAsync(Guid id,bool asNoTracking = true);
    ValueTask<User> CreateAsync(User user,bool saveChanges = true,CancellationToken cancellationToken = default);
    ValueTask<User> UpdateAsync(User user,bool saveChanges = true,CancellationToken cancellationToken = default);
    ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
}

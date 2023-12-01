using HomeTask.Domain.Commons;
using HomeTask.Domain.Models;
using HomeTask.Persistance.DataAccess;

namespace HomeTask.Persistance.Repositories;

public class UserRepository : EntityBaseRepository<User, AppDbContext>,IUserRepository
{
    private readonly AppDbContext dbContext;

    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    public IQueryable<User> Get(Func<User, bool> predicate, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public ValueTask<User?> GetById(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(user, saveChanges, cancellationToken);
    }
}

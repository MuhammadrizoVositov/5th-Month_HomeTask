using Microsoft.EntityFrameworkCore;
using N71BlogPost.Domain.Entity;
using N71BlogPost.Persistence.DataAccess;

namespace N71BlogPost.Persistence.Repositories.UserRepository;

public class UserRepository : EntityBaseRepository<User, AppDbContext>, IUserRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }

    public ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.Delete(user, saveChanges, cancellationToken);

    public ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = true)=>base.GetByIdAsync(id, asNoTracking);
   

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)=>
        base.Update(user, saveChanges, cancellationToken);
   

   public ValueTask<User> CreateAsync(User user, bool saveChanges, CancellationToken cancellationToken)=>
        base.CreateAsync(user, saveChanges, cancellationToken);
   

    public IQueryable<User> Get(bool asNoTracking)=>
        base.Get(asNoTracking);
}

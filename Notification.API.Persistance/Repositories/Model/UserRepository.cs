using Notification.API.Domain.Common.Entitys;
using Notification.API.Persistance.DataContext;
using Notification.API.Persistance.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Persistance.Repositories.Interfaces;
public class UserRepository : EntityRepositoryBase<User, NotificationDbContext>, IUserRepository
{
    public UserRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }

    IQueryable<User> IUserRepository.Get(Expression<Func<User, bool>>? predicate, bool asNoTracking)
    {
      return  base.Get(predicate, asNoTracking);
    }

    ValueTask<User?> IUserRepository.GetByIdAsync(Guid userId, bool asNoTracking=false, CancellationToken cancellationToken=default)
    {
       return base.GetByIdAsync(userId, asNoTracking, cancellationToken);

    }

    ValueTask<IList<User>> IUserRepository.GetByIdsAsync(IEnumerable<Guid> usersId, bool asNoTracking, CancellationToken cancellationToken)
    {
        return base.GetByIdsAsync(usersId, asNoTracking, cancellationToken);
    }
}

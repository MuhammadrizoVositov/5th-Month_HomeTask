using Notification.API.Domain.Common.Entitys;
using Notification.API.Persistance.DataContext;
using Notification.API.Persistance.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Persistance.Repositories.Interfaces;
public class UserSettingsRepository : EntityRepositoryBase<UserSettings, NotificationDbContext>, IUserSettingsRepository
{
    public UserSettingsRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }
    ValueTask<UserSettings?> IUserSettingsRepository.GetByIdAsync(Guid userId, bool asNoTracking, CancellationToken cancellationToken)
    {
      return   base.GetByIdAsync(userId, asNoTracking, cancellationToken);
    }
}

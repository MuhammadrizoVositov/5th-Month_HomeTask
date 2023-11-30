using Notification.API.Domain.Common.Entity;
using Notification.API.Domain.Common.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Persistance.Repositories.Interface;
public interface IUserSettingsRepository
{
    ValueTask<UserSettings?> GetByIdAsync(
       Guid userId,
       bool asNoTracking = false,
       CancellationToken cancellationToken = default
   );
}


using Notification.API.Domain.Common.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Application.Common.Identity;
public interface IUserSettingService
{
    public ValueTask<UserSettings?> GetByIdAsync(Guid userSettingsId, bool asNoTracking = true, CancellationToken cancellationToken = default);
}

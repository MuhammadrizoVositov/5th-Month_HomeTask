using Notification.API.Application.Common.Queriying;
using Notification.API.Domain.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Application.Common.Notifications.Service;
public interface ISmsHistoryService
{
    ValueTask<IList<SmsHistory>> GetByFilterAsync(
    FilterPagination paginationOptions,
    bool asNoTracking = false,
    CancellationToken cancellationToken = default
);

    ValueTask<SmsHistory> CreateAsync(
        SmsHistory smsHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}

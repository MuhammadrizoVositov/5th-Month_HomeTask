using Notification.API.Application.Common.Queriying;
using Notification.API.Domain.Common.Entity;
using Notification.API.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Application.Common.Notifications.Service;
public interface ISmsTemplateService
{
    ValueTask<IList<SmsTempalate>> GetByFilterAsync(
    FilterPagination paginationOptions,
    bool asNoTracking = false,
    CancellationToken cancellationToken = default
);

    ValueTask<SmsTempalate?> GetByTypeAsync(
        NotificationTemplateType templateType,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    );

    ValueTask<SmsTempalate> CreateAsync(
        SmsTempalate smsTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}

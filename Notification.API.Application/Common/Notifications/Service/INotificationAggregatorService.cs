using Notification.API.Application.Common.Notifications.Models;
using Notification.API.Application.Common.Queriying;
using Notification.API.Domain.Common.Entity;
using Notification.API.Domain.Common.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Application.Common.Notifications.Service;
public interface INotificationAggregatorService
{
    ValueTask<FuncResult<bool>> SendAsync(
      NotificationRequest notificationRequest,
      CancellationToken cancellationToken = default
  );

    ValueTask<IList<NotificationTempalate>> GetTemplatesByFilterAsync(
        NotificationTemplateFilter filter,
        CancellationToken cancellationToken = default
    );
}

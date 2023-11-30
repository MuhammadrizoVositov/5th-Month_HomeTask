using Notification.API.Application.Common.Notifications.Models;
using Notification.API.Domain.Common.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Application.Common.Notifications.Service;
public interface ISmsOrchestrationService
{
    ValueTask<FuncResult<bool>> SendAsync(
     SmsNotificationRequest request,
     CancellationToken cancellationToken = default
 );
}

using Notification.API.Application.Common.Notifications.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Application.Common.Notifications.Service;
public interface ISmsRenderingService
{
    ValueTask<string> RenderAsync(
       SmsMessage smsMessage,
       CancellationToken cancellationToken = default
   );
}

using Notification.API.Application.Common.Notifications.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Application.Common.Notifications.Service;
public interface IEmailRenderingService
{
    ValueTask<string> RenderAsync(
       EmailMessage emailMessage,
       // string template,
       // Dictionary<string, string> variables,
       CancellationToken cancellationToken = default
   );
}

﻿using Notification.API.Application.Common.Notifications.Models;
using Notification.API.Domain.Common.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Application.Common.Notifications.Service;
public interface IEmailOrchestrationService
{
    ValueTask<FuncResult<bool>> SendAsync(
      EmailNotificationRequest request,
      CancellationToken cancellationToken = default
  );
}

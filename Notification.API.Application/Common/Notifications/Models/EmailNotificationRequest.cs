﻿using Notification.API.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Application.Common.Notifications.Models;
public class EmailNotificationRequest:NotificationRequest
{
    public EmailNotificationRequest() => Type = NotificationType.Email;
}
    
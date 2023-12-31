﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Application.Common.Notifications.Models;
public abstract class NotificationMessage
{
    public Guid SenderUserId { get; set; }

    public Guid ReceiverUserId { get; set; }

    public Dictionary<string, string> Variables { get; set; }

    public bool IsSuccessful { get; set; }

    public string? ErrorMessage { get; set; }
}


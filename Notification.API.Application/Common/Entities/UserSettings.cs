using Notification.API.Domain.Common.Entitys;
using Notification.API.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Application.Common.Entities;
public class UserSettings:IEntity
{
    public Guid Id { get; set; }

    public NotificationType? PreferredNotificationType { get; set; }
}


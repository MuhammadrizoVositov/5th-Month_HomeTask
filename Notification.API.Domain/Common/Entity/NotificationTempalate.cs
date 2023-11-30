using Notification.API.Domain.Common.Entitys;
using Notification.API.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Domain.Common.Entity;
public abstract class NotificationTempalate:IEntity
{
    public Guid Id { get; set; }

    public string Content { get; set; } = default!;

    public NotificationType Type { get; set; }

    public NotificationTemplateType TemplateType { get; set; }

    public IList<NotificationHistory> Histories { get; set; } = new List<NotificationHistory>();
}

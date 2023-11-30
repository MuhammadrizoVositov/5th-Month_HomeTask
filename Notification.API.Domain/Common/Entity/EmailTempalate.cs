using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Notification.API.Domain.Common.Enums.NotificationType;

namespace Notification.API.Domain.Common.Entity;    
public class EmailTempalate:NotificationTempalate
{
    public EmailTempalate()
    {
        Type = Type.Email;
    }

    public string Subject { get; set; } = default!;
}

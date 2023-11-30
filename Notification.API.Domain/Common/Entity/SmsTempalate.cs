using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Notification.API.Domain.Common.Enums.NotificationType;

namespace Notification.API.Domain.Common.Entity;
public class SmsTempalate : NotificationTempalate
{
    public SmsTempalate() 
    {
        Type = Type.Sms;
    }
}

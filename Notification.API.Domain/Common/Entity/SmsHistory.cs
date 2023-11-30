using Notification.API.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Domain.Common.Entity;
public class SmsHistory:NotificationHistory
{
    public SmsHistory()
    {
        Type = NotificationType.Sms;
    }

    public string SenderPhoneNumber { get; set; } = default!;

    public string ReceiverPhoneNumber { get; set; } = default!;

    [NotMapped]
    public SmsTempalate SmsTemplate
    {
        get => Template is not null ? Template as SmsTempalate : null;
        set => Template = value;
    }
}

using Microsoft.Extensions.Options;
using Notification.API.Application.Common.Notifications.Brokers;
using Notification.API.Application.Common.Notifications.Models;
using Notification.API.Infrostructure.Common.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Infrostructure.Common.Notification.Broker;
public class SmtpEmailSenderBroker : IEmailSenderBroker
{
    private readonly SmtpEmailSenderSettings _smtpEmailSenderSettings;

    public SmtpEmailSenderBroker(IOptions<SmtpEmailSenderSettings> smtpEmailSenderSettings)
    {
        _smtpEmailSenderSettings = smtpEmailSenderSettings.Value;
    }
   

    ValueTask<bool> IEmailSenderBroker.SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

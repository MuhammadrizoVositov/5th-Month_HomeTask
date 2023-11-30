using AutoMapper;
using Microsoft.Extensions.Options;
using Notification.API.Application.Common.Identity;
using Notification.API.Application.Common.Notifications.Models;
using Notification.API.Application.Common.Notifications.Service;
using Notification.API.Application.Common.Queriying;
using Notification.API.Domain.Common.Entity;
using Notification.API.Domain.Common.Exeptions;
using Notification.API.Infrostructure.Common.Identity;
using Notification.API.Infrostructure.Common.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notification.API.Application.Common.Identity;
using Notification.API.Domain.Common.Enums;
using Notification.API.Domain.Common.Extesion;

namespace Notification.API.Infrostructure.Common.Service;
public class NotificationAggregatorService:INotificationAggregatorService
{
    private readonly IMapper _mapper;
    private readonly IOptions<NotificationSettings> _notificationSettings;
    private readonly ISmsOrchestrationService _smsOrchestrationService;
    private readonly IEmailOrchestrationService _emailOrchestrationService;
    private readonly IUserService _userService;
    private readonly IUserSettingService _userSettingsService;
    private readonly ISmsTemplateService _smsTemplateService;
    private readonly IEmailTemplateService _emailTemplateService;

    public NotificationAggregatorService(
        IMapper mapper,
        IOptions<NotificationSettings> notificationSettings,
        ISmsTemplateService smsTemplateService,
        IEmailTemplateService emailTemplateService,
        ISmsOrchestrationService smsOrchestrationService,
        IEmailOrchestrationService emailOrchestrationService,
        IUserSettingService userSettingsService,
        IUserService userService
    )
    {
        _mapper = mapper;
        _notificationSettings = notificationSettings;
        _smsOrchestrationService = smsOrchestrationService;
        _emailOrchestrationService = emailOrchestrationService;
        _smsTemplateService = smsTemplateService;
        _emailTemplateService = emailTemplateService;
        _userSettingsService = userSettingsService;
        _userService = userService;
    }

    public async ValueTask<IList<NotificationTempalate>> GetTemplatesByFilterAsync(NotificationTemplateFilter filter, CancellationToken cancellationToken = default)
    {
        {
            var templates = new List<NotificationTempalate>();

            if (filter.TemplateType.Contains(NotificationType.Sms))
                templates.AddRange(
                    await _smsTemplateService.GetByFilterAsync(filter, cancellationToken: cancellationToken));

            if (filter.TemplateType.Contains(NotificationType.Email))
                templates.AddRange(
                    await _emailTemplateService.GetByFilterAsync(filter, cancellationToken: cancellationToken));

            return templates;
        }
    }

    public async ValueTask<FuncResult<bool>> SendAsync(NotificationRequest notificationRequest, CancellationToken cancellationToken = default)
    {
        var sendNotificationTask = async () =>
        {
            // If sender is not specified, get system user
            var senderUser = notificationRequest.SenderUserId.HasValue
                ? await _userService.GetByIdAsync(notificationRequest.SenderUserId.Value,
                    cancellationToken: cancellationToken)
                : await _userService.GetSystemUserAsync(true, cancellationToken);

            notificationRequest.SenderUserId = senderUser!.Id;

            var receiverUser = await _userService.GetByIdAsync(notificationRequest.ReceiverUserId,
                cancellationToken: cancellationToken);

            // If notification provider type is not specified, get from receiver user settings
            if (!notificationRequest.Type.HasValue && receiverUser!.UserSettings.PreferredNotificationType.HasValue)
                notificationRequest.Type = receiverUser!.UserSettings.PreferredNotificationType!.Value;

            // If user not specified preferred notification type get from settings
            if (!notificationRequest.Type.HasValue)
                notificationRequest.Type = _notificationSettings.Value.DefaultNotificationType;

            var sendNotificationTask = notificationRequest.Type switch
            {
                NotificationType.Sms => _smsOrchestrationService.SendAsync(
                    _mapper.Map<SmsNotificationRequest>(notificationRequest),
                    cancellationToken),
                NotificationType.Email => _emailOrchestrationService.SendAsync(
                    _mapper.Map<EmailNotificationRequest>(notificationRequest),
                    cancellationToken),
                _ => throw new NotImplementedException("This type of notification is not supported yet.")
            };

            var sendNotificationResult = await sendNotificationTask;
            return sendNotificationResult.Data;
        };
        return await sendNotificationTask.GetValueAsync();
    }
}

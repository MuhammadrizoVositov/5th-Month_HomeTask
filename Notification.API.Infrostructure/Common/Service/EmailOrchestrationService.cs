using AutoMapper;
using Notification.API.Application.Common.Identity;
using Notification.API.Application.Common.Notifications.Models;
using Notification.API.Application.Common.Notifications.Service;
using Notification.API.Domain.Common.Entity;
using Notification.API.Domain.Common.Enums;
using Notification.API.Domain.Common.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notification.API.Domain.Common.Extesion;

namespace Notification.API.Infrostructure.Common.Service;
public class EmailOrchestrationService:IEmailOrchestrationService
{
    private readonly IMapper _mapper;
    private readonly IEmailTemplateService _emailTemplateService;
    private readonly IEmailRenderingService _emailRenderingService;
    private readonly IEmailSenderService _emailSenderService;
    private readonly IEmailHistoryService _emailHistoryService;
    private readonly IUserService _userService;

    public EmailOrchestrationService(
        IMapper mapper,
        IEmailTemplateService emailTemplateService,
        IEmailRenderingService emailRenderingService,
        IEmailSenderService emailSenderService,
        IEmailHistoryService emailHistoryService,
        IUserService userService
    )
    {
        _mapper = mapper;
        _emailTemplateService = emailTemplateService;
        _emailRenderingService = emailRenderingService;
        _emailSenderService = emailSenderService;
        _emailHistoryService = emailHistoryService;
        _userService = userService;
    }

    public async ValueTask<FuncResult<bool>> SendAsync(EmailNotificationRequest request, CancellationToken cancellationToken = default)
    {
        {
            var sendNotificationRequest = async () =>
            {
                var message = _mapper.Map<EmailMessage>(request);

      
                var senderUser = (await _userService
                    .GetByIdAsync(request.SenderUserId!.Value, cancellationToken: cancellationToken))!;

                var receiverUser = (await _userService
                    .GetByIdAsync(request.ReceiverUserId, cancellationToken: cancellationToken))!;

                message.SendEmailAddress = senderUser.EmailAddress;
                message.ReceiverEmailAddress = receiverUser.EmailAddress;

                
                message.Template =
                    await _emailTemplateService.GetByTypeAsync(request.TemplateType, true, cancellationToken) ??
                    throw new InvalidOperationException(
                        $"Invalid template for sending {NotificationType.Sms} notification");

           
                await _emailRenderingService.RenderAsync(message, cancellationToken);

                
                await _emailSenderService.SendAsync(message, cancellationToken);

                
                var history = _mapper.Map<EmailHistory>(message);
                await _emailHistoryService.CreateAsync(history, cancellationToken: cancellationToken);

                return history.IsSuccessful;
            };

            return await sendNotificationRequest.GetValueAsync();
                
                

        };
    }
}

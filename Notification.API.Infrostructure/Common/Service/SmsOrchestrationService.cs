using AutoMapper;
using Notification.API.Application.Common.Identity;
using Notification.API.Application.Common.Notifications.Models;
using Notification.API.Application.Common.Notifications.Service;
using Notification.API.Domain.Common.Entity;
using Notification.API.Domain.Common.Enums;
using Notification.API.Domain.Common.Exeptions;
using Notification.API.Persistance.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Notification.API.Domain.Common.Extesion;

namespace Notification.API.Infrostructure.Common.Service;
public class SmsOrchestrationService : ISmsOrchestrationService
{
    private readonly IMapper _mapper;
    private readonly ISmsSenderService _smsSenderService;
    private readonly ISmsHistoryService _smsHistoryService;
    private readonly NotificationDbContext _dbContext;
    private readonly IUserService _userService;
    private readonly ISmsTemplateService _smsTemplateService;
    private readonly ISmsRenderingService _smsRenderingService;

    public SmsOrchestrationService(
        IMapper mapper,
        ISmsTemplateService smsTemplateService,
        ISmsRenderingService smsRenderingService,
        ISmsSenderService smsSenderService,
        ISmsHistoryService smsHistoryService,
        NotificationDbContext dbContext,
        IUserService userService
    )
    {
        _mapper = mapper;
        _smsTemplateService = smsTemplateService;
        _smsRenderingService = smsRenderingService;
        _smsSenderService = smsSenderService;
        _smsHistoryService = smsHistoryService;
        _dbContext = dbContext;
        _userService = userService;
    }

    public async ValueTask<FuncResult<bool>> SendAsync(SmsNotificationRequest request, CancellationToken cancellationToken = default)
    {
        var sendNotificationRequest = async () =>
        {
            var message = _mapper.Map<SmsMessage>(request);

          
            var senderUser =
                (await _userService.GetByIdAsync(request.SenderUserId!.Value, cancellationToken: cancellationToken))!;

            var receiverUser =
                (await _userService.GetByIdAsync(request.ReceiverUserId, cancellationToken: cancellationToken))!;

            message.SenderPhoneNumber = senderUser.PhoneNumber;
            message.ReceiverPhoneNumber = receiverUser.PhoneNumber;

            
            message.Template =
                await _smsTemplateService.GetByTypeAsync(request.TemplateType, true, cancellationToken) ??
                throw new InvalidOperationException(
                    $"Invalid template for sending {NotificationType.Sms} notification");

         
            await _smsRenderingService.RenderAsync(message, cancellationToken);

       
            await _smsSenderService.SendAsync(message, cancellationToken);

     

            var history = _mapper.Map<SmsHistory>(message);
            var test = _dbContext.Entry(history.Template).State;

            await _smsHistoryService.CreateAsync(history, cancellationToken: cancellationToken);

            return history.IsSuccessful;
        };

        return await sendNotificationRequest.GetValueAsync();
    }
}


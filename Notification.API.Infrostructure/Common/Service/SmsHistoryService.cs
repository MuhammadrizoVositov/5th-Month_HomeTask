using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notification.API.Application.Common.Notifications.Service;
using Notification.API.Application.Common.Queriying;
using Notification.API.Domain.Common.Entity;
using Notification.API.Domain.Common.Enums;
using Notification.API.Persistance.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Infrostructure.Common.Service;
public class SmsHistoryService:ISmsHistoryService
{
    private readonly ISmsHistoryRepository _smsHistoryRepository;
    private readonly IValidator<SmsHistory> _smsHistoryValidator;

    public SmsHistoryService(ISmsHistoryRepository smsHistoryRepository, IValidator<SmsHistory> smsHistoryValidator)
    {
        _smsHistoryRepository = smsHistoryRepository;
        _smsHistoryValidator = smsHistoryValidator;
    }

    public async ValueTask<SmsHistory> CreateAsync(SmsHistory smsHistory, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        {
            var validationResult = await _smsHistoryValidator.ValidateAsync(smsHistory,
                options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
                cancellationToken);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            return await _smsHistoryRepository.CreateAsync(smsHistory, saveChanges, cancellationToken);
        }
    }

    public async ValueTask<IList<SmsHistory>> GetByFilterAsync(FilterPagination paginationOptions, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await _smsHistoryRepository.Get().ApplyPagination(paginationOptions).ToListAsync(cancellationToken);
    }
}

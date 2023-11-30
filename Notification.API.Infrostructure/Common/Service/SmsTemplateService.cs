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
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Infrostructure.Common.Service;
public class SmsTemplateService : ISmsTemplateService
{
    private readonly ISmsTemplateRepository _smsTemplateRepository;
    private readonly IValidator<SmsTempalate> _smsTemplateValidator;

    public SmsTemplateService(
        ISmsTemplateRepository smsTemplateRepository,
        IValidator<SmsTempalate> smsTemplateValidator
    )
    {
        _smsTemplateRepository = smsTemplateRepository;
        _smsTemplateValidator = smsTemplateValidator;
    }
    public IQueryable<SmsTempalate> Get(
      Expression<Func<SmsTempalate, bool>>? predicate = default,
      bool asNoTracking = false
  ) =>
      _smsTemplateRepository.Get(predicate, asNoTracking);
    public ValueTask<SmsTempalate> CreateAsync(SmsTempalate smsTemplate, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        {
            var validationResult = _smsTemplateValidator.Validate(smsTemplate);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            return _smsTemplateRepository.CreateAsync(smsTemplate, saveChanges, cancellationToken);
        }
    }

    public async ValueTask<IList<SmsTempalate>> GetByFilterAsync(FilterPagination paginationOptions, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
       return await Get(asNoTracking: asNoTracking)
        .ApplyPagination(paginationOptions)
        .ToListAsync(cancellationToken: cancellationToken);
    }

    public async ValueTask<SmsTempalate?> GetByTypeAsync(NotificationTemplateType templateType, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
      return  await _smsTemplateRepository.Get(template => template.TemplateType == templateType, asNoTracking)
            .SingleOrDefaultAsync(cancellationToken);
    }
}

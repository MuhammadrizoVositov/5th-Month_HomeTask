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
public class EmailTemplateService:IEmailTemplateService
{
    private readonly IEmailTemplateRepository _emailTemplateRepository;
    private readonly IValidator<EmailTempalate> _emailTemplateValidator;

    public EmailTemplateService(
        IEmailTemplateRepository emailTemplateRepository,
        IValidator<EmailTempalate> emailTemplateValidator
    )
    {
        _emailTemplateRepository = emailTemplateRepository;
        _emailTemplateValidator = emailTemplateValidator;
    }
    public IQueryable<EmailTempalate> Get(
        Expression<Func<EmailTempalate, bool>>? predicate = default,
        bool asNoTracking = false
    ) =>
        _emailTemplateRepository.Get(predicate, asNoTracking);

    public ValueTask<EmailTempalate> CreateAsync(EmailTempalate emailTemplate, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = _emailTemplateValidator.Validate(emailTemplate);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return _emailTemplateRepository.CreateAsync(emailTemplate, saveChanges, cancellationToken);
    }

    public async ValueTask<IList<EmailTempalate>> GetByFilterAsync(FilterPagination paginationOptions, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await Get(asNoTracking: asNoTracking)
          .ApplyPagination(paginationOptions)
          .ToListAsync(cancellationToken: cancellationToken);
    }

    public async ValueTask<EmailTempalate?> GetByTypeAsync(NotificationTemplateType templateType, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
      return  await _emailTemplateRepository.Get(template => template.TemplateType == templateType, asNoTracking)
          .SingleOrDefaultAsync(cancellationToken);
    }
}

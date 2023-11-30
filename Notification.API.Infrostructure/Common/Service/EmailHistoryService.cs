using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notification.API.Application.Common.Notifications.Models;
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
public class EmailHistoryService : IEmailHistoryService
{
    private readonly IEmailHistoryRepository _emailHistoryRepository;
    private readonly IValidator<EmailHistory> _emailHistoryValidator;

    public EmailHistoryService(IEmailHistoryRepository emailHistoryRepository, IValidator<EmailHistory> emailHistoryValidator)
    {
        _emailHistoryRepository = emailHistoryRepository;
        _emailHistoryValidator = emailHistoryValidator;
    }
    public async ValueTask<EmailHistory> CreateAsync(EmailHistory emailHistory, bool saveChanges=true, CancellationToken cancellationToken=default)
    {
        var validationResult = await _emailHistoryValidator.ValidateAsync(emailHistory,
        options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
        cancellationToken);
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        return await _emailHistoryRepository.CreateAsync(emailHistory, saveChanges, cancellationToken);
    }

    public async ValueTask<IList<EmailHistory>> GetByFilterAsync(FilterPagination paginationOptions, bool asNoTracking, CancellationToken cancellationToken)
    {
      return  await _emailHistoryRepository.Get().ApplyPagination(paginationOptions).ToListAsync(cancellationToken);
    }
}


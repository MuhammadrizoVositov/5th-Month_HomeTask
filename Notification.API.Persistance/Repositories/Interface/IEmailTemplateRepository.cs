using Notification.API.Domain.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Persistance.Repositories.Interface;
public interface IEmailTemplateRepository
{
    IQueryable<EmailTempalate> Get(
    Expression<Func<EmailTempalate, bool>>? predicate = default,
    bool asNoTracking = false
    );

    ValueTask<EmailTempalate> CreateAsync(
        EmailTempalate emailTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}

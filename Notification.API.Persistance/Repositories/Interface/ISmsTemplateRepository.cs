using Notification.API.Domain.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Persistance.Repositories.Interface;
public interface ISmsTemplateRepository
{
    IQueryable<SmsTempalate> Get(Expression<Func<SmsTempalate, bool>>? predicate = default, bool asNoTracking = false);
    ValueTask<SmsTempalate> CreateAsync(
        SmsTempalate smsTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}

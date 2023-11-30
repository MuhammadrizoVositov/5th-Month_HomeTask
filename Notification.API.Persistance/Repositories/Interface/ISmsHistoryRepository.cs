using Notification.API.Domain.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Persistance.Repositories.Interface;
public interface ISmsHistoryRepository
{
    IQueryable<SmsHistory> Get(
    Expression<Func<SmsHistory, bool>>? predicate = default,
    bool asNoTracking = false
);

    ValueTask<SmsHistory> CreateAsync(
        SmsHistory smsHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}

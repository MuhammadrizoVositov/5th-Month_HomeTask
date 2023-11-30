using Microsoft.EntityFrameworkCore;
using Notification.API.Domain.Common.Entity;
using Notification.API.Persistance.DataContext;
using Notification.API.Persistance.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Persistance.Repositories.Interfaces;
public class SmsHistoryRepository : EntityRepositoryBase<SmsHistory, NotificationDbContext>, ISmsHistoryRepository

{
    public SmsHistoryRepository(NotificationDbContext dbContext) : base(dbContext)
    {

    }

    IQueryable<SmsHistory> ISmsHistoryRepository.Get(Expression<Func<SmsHistory, bool>>? predicate, bool asNoTracking)
    {
      return  base.Get(predicate, asNoTracking);
    }
   public async ValueTask<SmsHistory> CreateAsync(SmsHistory smsHistory, bool saveChanges=true, CancellationToken cancellationToken=default)
    {
        if (smsHistory.SmsTemplate is not null)
            DbContext.Entry(smsHistory.SmsTemplate).State = EntityState.Unchanged;

        var createdHistory = await base.CreateAsync(smsHistory, saveChanges, cancellationToken);

        if (smsHistory.SmsTemplate is not null)
            DbContext.Entry(smsHistory.SmsTemplate).State = EntityState.Detached;

        return createdHistory;
    }

}

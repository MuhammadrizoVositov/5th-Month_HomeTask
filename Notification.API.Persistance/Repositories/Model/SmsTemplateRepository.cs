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
public class SmsTemplateRepository: EntityRepositoryBase<SmsTempalate, NotificationDbContext>, ISmsTemplateRepository
{
    public SmsTemplateRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }

    ValueTask<SmsTempalate> ISmsTemplateRepository.CreateAsync(SmsTempalate smsTemplate, bool saveChanges, CancellationToken cancellationToken)
    {
      return  base.CreateAsync(smsTemplate, saveChanges, cancellationToken);
    }

    IQueryable<SmsTempalate> ISmsTemplateRepository.Get(Expression<Func<SmsTempalate, bool>>? predicate, bool asNoTracking)
    {
        return base.Get(predicate, asNoTracking);
    }

}

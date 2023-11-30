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
public class EmailHistoryRepository : EntityRepositoryBase<EmailHistory, NotificationDbContext>, IEmailHistoryRepository
{
    public EmailHistoryRepository(NotificationDbContext dbContext) : base(dbContext)
    {

    }
    public IQueryable<EmailHistory> Get(Expression<Func<EmailHistory, bool>>? predicate=default, bool asNoTracking = false)
    {
       return base.Get(predicate, asNoTracking);
        
    }   

    public async ValueTask<EmailHistory>CreateAsync(EmailHistory emailHistory, bool saveChanges=true, CancellationToken cancellationToken=default)
    {
        {
            if (emailHistory.EmailTemplate is not null)
                DbContext.Entry(emailHistory.EmailTemplate).State = EntityState.Unchanged;

            var createdHistory = await base.CreateAsync(emailHistory, saveChanges, cancellationToken);

            if (emailHistory.EmailTemplate is not null)
                DbContext.Entry(emailHistory.EmailTemplate).State = EntityState.Detached;

            return createdHistory;
        }
    }



}

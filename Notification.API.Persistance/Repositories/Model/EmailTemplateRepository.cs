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
public class EmailTemplateRepository : EntityRepositoryBase<EmailTempalate, NotificationDbContext>, IEmailTemplateRepository
{
    public EmailTemplateRepository(NotificationDbContext dbContext) : base(dbContext)
    {

    }


   public  ValueTask<EmailTempalate> CreateAsync(EmailTempalate emailTemplate, bool saveChanges, CancellationToken cancellationToken)
    {
        return base.CreateAsync(emailTemplate, saveChanges, cancellationToken);
    }

     public IQueryable<EmailTempalate> Get(Expression<Func<EmailTempalate, bool>>? predicate, bool asNoTracking)
    {
        return base.Get(predicate, asNoTracking);
    }
}




                        

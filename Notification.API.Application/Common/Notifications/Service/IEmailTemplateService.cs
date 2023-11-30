using Notification.API.Application.Common.Queriying;
using Notification.API.Domain.Common.Entity;
using Notification.API.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Application.Common.Notifications.Service;
public interface IEmailTemplateService
{
    ValueTask<IList<EmailTempalate>> GetByFilterAsync(
      FilterPagination paginationOptions,
      bool asNoTracking = false,
      CancellationToken cancellationToken = default
  );

    ValueTask<EmailTempalate?> GetByTypeAsync(
        NotificationTemplateType templateType,
    bool asNoTracking = false,
        CancellationToken cancellationToken = default
    );

    ValueTask<EmailTempalate> CreateAsync(
        EmailTempalate emailTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}

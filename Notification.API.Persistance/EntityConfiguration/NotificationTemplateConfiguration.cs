using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notification.API.Domain.Common.Entity;
using Notification.API.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Persistance.EntityConfiguration;
public class NotificationTemplateConfiguration : IEntityTypeConfiguration<NotificationTempalate>
{
    public void Configure(EntityTypeBuilder<NotificationTempalate> builder)
    {
        builder.Property(template => template.Content).HasMaxLength(129_533);

        builder.HasIndex(template => new
        {
            template.Type,
            template.TemplateType
        })
        .IsUnique();

        builder.ToTable("NotificationTemplates")
            .HasDiscriminator(emailTemplate => emailTemplate.Type)
            .HasValue<EmailTempalate>(NotificationType.Email)
            .HasValue<SmsTempalate>(NotificationType.Sms);
    }
}

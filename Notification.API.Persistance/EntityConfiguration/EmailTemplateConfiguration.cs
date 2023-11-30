﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notification.API.Domain.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Persistance.EntityConfiguration;
public class EmailTemplateConfiguration : IEntityTypeConfiguration<EmailTempalate>
{
    public void Configure(EntityTypeBuilder<EmailTempalate> builder)
    {
        builder.Property(template => template.Subject).IsRequired().HasMaxLength(256);
    }
}

using Microsoft.EntityFrameworkCore;
using Notification.API.Domain.Common.Entity;
using Notification.API.Domain.Common.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Persistance.DataContext;
public class NotificationDbContext:DbContext
{
    public DbSet<SmsTempalate> SmsTemplates => Set<SmsTempalate>();

    public DbSet<EmailTempalate> EmailTemplates => Set<EmailTempalate>();

    public DbSet<SmsHistory> SmsHistories => Set<SmsHistory>();

    public DbSet<EmailHistory> EmailHistories => Set<EmailHistory>();

    public DbSet<User> Users => Set<User>();
    public DbSet<UserSettings> UserSettings => Set<UserSettings>();

    public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NotificationDbContext).Assembly);
    }
}

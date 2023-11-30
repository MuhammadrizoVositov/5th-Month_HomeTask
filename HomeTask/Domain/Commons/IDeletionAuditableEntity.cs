namespace HomeTask.Domain.Commons;

public interface IDeletionAuditableEntity
{
    Guid DeletedBy { get; set; }
}

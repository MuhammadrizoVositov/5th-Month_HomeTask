namespace HomeTask.Domain.Commons;

public interface IModificationAuditableEntity
{
    Guid ModifiedBy { get; set; }
}

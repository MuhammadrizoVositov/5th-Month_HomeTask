namespace HomeTask.Domain.Commons;

public interface ICreationAuditableEntity
{
    Guid CreatedBy { get; set; }
}

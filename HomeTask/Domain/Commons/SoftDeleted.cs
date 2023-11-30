namespace HomeTask.Domain.Commons;

public class SoftDeleted : IEntity
{
    public bool IsDeleted { get; set; }
    public DateTime DeletedDate { get; set; }
    public Guid Id { get; set; }
}

namespace HomeTask.Domain.Commons;

public interface ISoftDeleted
{
    bool IsDeleted { get; set; }
    DateTime DeletedDate { get; set; }
}

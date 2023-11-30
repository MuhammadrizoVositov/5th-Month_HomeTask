namespace HomeTask.Domain.Commons;

public interface IAuditable
{
    DateTime CreatedDate { get; set; }
    DateTime UpdatedDate { get; set; }
}

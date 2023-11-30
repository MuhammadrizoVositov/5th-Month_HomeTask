namespace HomeTask.Domain.Models;

public class Book
{
    public Guid UserId { get; set; }
    public int PageSize { get; set; }
    public string Description { get; set; } = default!;
    public Guid CreatedBy { get; set; }
    public Guid ModifiedBy { get; set; }
    public Guid DeletedBy { get; set; }
}

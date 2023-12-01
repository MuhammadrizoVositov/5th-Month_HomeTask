using HomeTask.Domain.Commons;

namespace HomeTask.Domain.Models;

public class User:SoftDeleted
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}

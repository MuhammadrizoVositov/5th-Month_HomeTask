namespace HomeTask.Domain.Brokers;

public interface IRequestedUserContextProvider
{
    Guid GetUserIdAsync(CancellationToken cancellationToken = default);
}


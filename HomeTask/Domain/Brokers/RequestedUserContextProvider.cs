using HomeTask.Domain.Constants;
using Microsoft.Extensions.Options;

namespace HomeTask.Domain.Brokers;

public class RequestedUserContextProvider : IRequestedUserContextProvider
{
    private readonly IHttpContextAccessor accessor;
    private readonly IOptions<RequestedUserContextSettings> options;

    public RequestedUserContextProvider(IHttpContextAccessor accessor, IOptions<RequestedUserContextSettings> options)
    {
        this.accessor = accessor;
        this.options = options;
    }

    public Guid GetUserIdAsync(CancellationToken cancellationToken = default)
    {
        var user = accessor.HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimsConstant.UserId).Value;

        return user is not null ? Guid.Parse(user) : options.Value.SystemUserId;

    }
}

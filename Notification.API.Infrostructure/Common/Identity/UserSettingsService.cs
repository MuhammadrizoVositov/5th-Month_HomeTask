using Notification.API.Application.Common.Identity;
using Notification.API.Domain.Common.Entitys;
using Notification.API.Persistance.Repositories.Interface;

namespace Notification.API.Infrostructure.Common.Identity;
public class UserSettingsService : IUserSettingService
{

    private readonly IUserSettingsRepository _userSettingsRepository;

    public UserSettingsService(IUserSettingsRepository userSettingsRepository)
    {
        _userSettingsRepository = userSettingsRepository;
    }

    public ValueTask<UserSettings?> GetByIdAsync(Guid userSettingsId, bool asNoTracking=true, CancellationToken cancellationToken=default)
    {
        return _userSettingsRepository.GetByIdAsync(userSettingsId, asNoTracking, cancellationToken);
    }
}       
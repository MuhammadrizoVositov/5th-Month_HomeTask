using N71BlogPost.Application.Services;
using N71BlogPost.Domain.Entity;
using N71BlogPost.Persistence.Repositories.UserRepository;

namespace N71BlogPost.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
       return await _userRepository.CreateAsync(user, saveChanges, cancellationToken);
    }

    public async ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var delete=await _userRepository.GetByIdAsync(user.Id);
        return await _userRepository.DeleteAsync(delete, saveChanges, cancellationToken);
    }

    public IQueryable<User> Get(bool asNoTracking = true)
    {
        return  _userRepository.Get(asNoTracking).AsQueryable();
    }

    public async ValueTask<User> GetByIdAsync(Guid id, bool asNoTracking = true)
    {
        return await _userRepository.GetByIdAsync(id, asNoTracking);
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var update = await _userRepository.GetByIdAsync(user.Id);
        update.FirstName = user.FirstName;
        update.LastName = user.LastName;
        update.EmailAdress = user.EmailAdress;

        return await _userRepository.UpdateAsync(update,saveChanges,cancellationToken);
    }
}

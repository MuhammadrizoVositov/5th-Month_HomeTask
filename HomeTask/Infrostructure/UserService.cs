using HomeTask.Application;
using HomeTask.Domain.Models;
using HomeTask.Persistance.Repositories;

namespace HomeTask.Infrostructure;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    ValueTask<User> IUserService.CreateAsync(User user, bool saveChanges, CancellationToken cancellationToken)
    {
        return userRepository.CreateAsync(user, saveChanges, cancellationToken);
    }

    ValueTask<User> IUserService.DeleteAsync(User user, bool saveChanges, CancellationToken cancellationToken)
    {
        return userRepository.DeleteAsync(user, saveChanges, cancellationToken);
    }

    IQueryable<User> IUserService.Get(Func<User, bool> predicate, bool asNoTracking)
    {
        return userRepository.Get(predicate, asNoTracking);
    }

    ValueTask<User?> IUserService.GetById(Guid id, bool asNoTracking, CancellationToken cancellationToken)
    {
        return userRepository.GetById(id, asNoTracking, cancellationToken);
    }

    ValueTask<User> IUserService.UpdateAsync(User user, bool saveChanges, CancellationToken cancellationToken)
    {
        return userRepository.UpdateAsync(user, saveChanges, cancellationToken);
    }
}

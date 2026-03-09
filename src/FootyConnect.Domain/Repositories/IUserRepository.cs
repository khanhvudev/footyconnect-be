using FootyConnect.Domain.Entities;

namespace FootyConnect.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
}

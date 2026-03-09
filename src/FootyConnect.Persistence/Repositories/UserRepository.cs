using FootyConnect.CrossCuttingConcerns.DateTimes;
using FootyConnect.Domain.Entities;
using FootyConnect.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FootyConnect.Persistence.Repositories;

public class UserRepository(FootyConnectDbContext dbContext, IDateTimeProvider dateTimeProvider) 
    : Repository<User, Guid>(dbContext, dateTimeProvider), IUserRepository
{
    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await DbSet.SingleOrDefaultAsync(u => u.Email == email, cancellationToken);
    }
}

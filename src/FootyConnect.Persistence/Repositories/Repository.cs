using FootyConnect.CrossCuttingConcerns.DateTimes;
using FootyConnect.Domain.Entities;
using FootyConnect.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FootyConnect.Persistence.Repositories;

public class Repository<TEntity, TKey>(FootyConnectDbContext dbContext, IDateTimeProvider dateTimeProvider) 
    : IRepository<TEntity, TKey> where TEntity : Entity<TKey>
{
    private readonly FootyConnectDbContext _dbContext = dbContext;
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

    protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        entity.CreatedDateTime = _dateTimeProvider.OffsetUtcNow;
        await DbSet.AddAsync(entity, cancellationToken);
    }

    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        entity.UpdatedDateTime = _dateTimeProvider.OffsetUtcNow;
        return Task.CompletedTask;
    }

    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
    }

    public IQueryable<TEntity> GetQueryableSet()
    {
        return _dbContext.Set<TEntity>();
    }

    public async Task<List<T>> ToListAsync<T>(IQueryable<T> query)
    {
        return await query.ToListAsync();
    }
}

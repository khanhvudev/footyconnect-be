using FootyConnect.Domain.Entities;

namespace FootyConnect.Domain.Repositories;

public interface IRepository<TEntity, TKey> where TEntity : Entity<TKey>
{
    IQueryable<TEntity> GetQueryableSet();
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    void Delete(TEntity entity);
    Task<List<T>> ToListAsync<T>(IQueryable<T> query);
}

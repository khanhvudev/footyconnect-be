namespace FootyConnect.Domain.Entities;

public abstract class Entity<TKey>
{
    public TKey Id { get; set; } = default!;
    public DateTimeOffset CreatedDateTime { get; set; }
    public DateTimeOffset? UpdatedDateTime { get; set; }
}

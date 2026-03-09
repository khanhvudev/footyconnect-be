using FootyConnect.Domain.Entities;
using FootyConnect.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FootyConnect.Persistence;

public class FootyConnectDbContext(DbContextOptions<FootyConnectDbContext> options) : DbContext(options), IUnitOfWork
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TeamMember> TeamMembers { get; set; }
    public DbSet<TimeSlot> TimeSlots { get; set; }
    public DbSet<MatchRequest> MatchRequests { get; set; }
    public DbSet<FootballPitch> FootballPitches { get; set; }
}

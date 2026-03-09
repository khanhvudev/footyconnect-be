using FootyConnect.Domain.Repositories;
using FootyConnect.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FootyConnect.Persistence;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString, int? commandTimeout = null)
    {
        services.AddDbContext<FootyConnectDbContext>(options =>
        {
            options.UseSqlServer(connectionString, sql =>
            {
                if (commandTimeout.HasValue)
                {
                    sql.CommandTimeout(commandTimeout);
                }
            });
        });

        services.AddRepositories();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped(typeof(IUnitOfWork), services =>
        {
            return services.GetRequiredService<FootyConnectDbContext>();    
        });

        return services;
    }
}

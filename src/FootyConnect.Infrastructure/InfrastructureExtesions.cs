using FootyConnect.Application.Abstractions;
using FootyConnect.CrossCuttingConcerns.DateTimes;
using FootyConnect.Infrastructure.Authentication;
using FootyConnect.Infrastructure.DateTimes;
using Microsoft.Extensions.DependencyInjection;

namespace FootyConnect.Infrastructure;

public static class InfrastructureExtesions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDateTimeProvider();
        services.AddJwtProvider();
        services.AddPasswordHasher();

        return services;
    }

    public static IServiceCollection AddDateTimeProvider(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }

    public static IServiceCollection AddJwtProvider(this IServiceCollection services)
    {
        services.AddSingleton<IJwtProvider, JwtProvider>();
        return services;
    }

    public static IServiceCollection AddPasswordHasher(this IServiceCollection services)
    {
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        return services;
    }
}

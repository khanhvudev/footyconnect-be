using FootyConnect.Application.Abstractions.Commands;
using FootyConnect.Application.Abstractions.Queries;
using FootyConnect.Application.Common;
using Microsoft.Extensions.DependencyInjection;

namespace FootyConnect.Application;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddScoped<Dispatcher>();

        services.Scan(scan => scan.FromAssemblies(typeof(IQueryHandler<,>).Assembly)
            .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        return services;
    }
}

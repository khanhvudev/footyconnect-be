using FootyConnect.Application.Abstractions.Commands;
using FootyConnect.Application.Abstractions.Queries;
using FootyConnect.Application.Common.Results;
using Microsoft.Extensions.DependencyInjection;

namespace FootyConnect.Application.Common;

public class Dispatcher(IServiceProvider provider)
{
    private readonly IServiceProvider _provider = provider;

    public async Task<Result> DispatchAsync(ICommand command, CancellationToken cancellationToken)
    {
        Type type = typeof(ICommandHandler<>);
        Type[] typeArgs = [command.GetType()];
        Type handlerType = type.MakeGenericType(typeArgs);

        dynamic handler = _provider.GetRequiredService(handlerType);
        Task<Result> result = handler.HandleAsync((dynamic)command, cancellationToken);

        return await result;
    }

    public async Task<Result<T>> DispatchAsync<T>(ICommand<T> command, CancellationToken cancellationToken)
    {
        Type type = typeof(ICommandHandler<,>);
        Type[] typeArgs = [command.GetType(), typeof(T)];
        Type handlerType = type.MakeGenericType(typeArgs);

        dynamic handler = _provider.GetRequiredService(handlerType);
        Task<Result<T>> result = handler.HandleAsync((dynamic)command, cancellationToken);

        return await result; 
    }

    public async Task<Result<T>> DispatchAsync<T>(IQuery<T> query, CancellationToken cancellationToken = default)
    {
        Type type = typeof(IQueryHandler<,>);
        Type[] typeArgs = [query.GetType(), typeof(T)];
        Type handlerType = type.MakeGenericType(typeArgs);

        dynamic handler = _provider.GetRequiredService(handlerType);
        Task<Result<T>> result = handler.HandleAsync((dynamic)query, cancellationToken);

        return await result;
    }
}

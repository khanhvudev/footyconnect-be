using FootyConnect.Application.Common.Results;

namespace FootyConnect.Application.Abstractions.Queries;

public interface IQueryHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
{
    Task<Result<TResponse>> HandleAsync(TQuery query, CancellationToken cancellationToken);
}

using FootyConnect.Application.Abstractions.Queries;
using FootyConnect.Application.Common.Results;
using FootyConnect.Application.FootballPitches.DTOs;
using FootyConnect.Domain.Entities;
using FootyConnect.Domain.Repositories;

namespace FootyConnect.Application.FootballPitches.Get;

public class GetFootballPitchesQueryHandler(IRepository<FootballPitch, Guid> repository) : IQueryHandler<GetFootballPitchesQuery, IEnumerable<FootballPitchDto>>
{
    private readonly IRepository<FootballPitch, Guid> _repository = repository;

    public async Task<Result<IEnumerable<FootballPitchDto>>> HandleAsync(GetFootballPitchesQuery query, CancellationToken cancellationToken)
    {
        var footballPitches = await _repository.ToListAsync(_repository.GetQueryableSet());
        
        return Result.Success(footballPitches.ToDtos());
    }
}

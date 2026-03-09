using FootyConnect.Application.Common.Results;
using FootyConnect.Domain.Repositories;
using FootyConnect.Application.FootballPitches.DTOs;
using FootyConnect.Domain.Entities;
using FootyConnect.Application.Abstractions.Commands;

namespace FootyConnect.Application.FootballPitches.Create;

public class CreateFootballPitchCommandHandler(
    IRepository<FootballPitch, Guid> repository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateFootballPitchCommand, FootballPitchDto>
{
    private readonly IRepository<FootballPitch, Guid> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<FootballPitchDto>> HandleAsync(CreateFootballPitchCommand command, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.FootballPitch
        {
            Name = command.Name
        };

        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);  

        return Result.Success(entity.ToDto());
    }
}

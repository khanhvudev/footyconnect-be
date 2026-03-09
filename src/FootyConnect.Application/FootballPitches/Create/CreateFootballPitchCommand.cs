using FootyConnect.Application.Abstractions.Commands;
using FootyConnect.Application.FootballPitches.DTOs;

namespace FootyConnect.Application.FootballPitches.Create;

public record CreateFootballPitchCommand(string Name) : ICommand<FootballPitchDto>;

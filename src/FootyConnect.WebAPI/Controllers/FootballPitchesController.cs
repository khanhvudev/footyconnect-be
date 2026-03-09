using FootyConnect.Application.Common;
using FootyConnect.Application.Common.Results;
using FootyConnect.Application.FootballPitches.Create;
using FootyConnect.Application.FootballPitches.DTOs;
using FootyConnect.Application.FootballPitches.Get;
using FootyConnect.WebAPI.Models.FootballPitches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FootyConnect.WebAPI.Controllers;

[ApiController]
[Route("api/football-pitches")]
public class FootballPitchesController(Dispatcher dispatcher) : ControllerBase
{
    private readonly Dispatcher _dispatcher = dispatcher;

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<Result<IEnumerable<FootballPitchDto>>>> GetFootballPitches(CancellationToken cancellationToken)
    {
        var result = await _dispatcher.DispatchAsync(new GetFootballPitchesQuery(), cancellationToken);
        return result.ToActionResult();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<FootballPitchDto>> CreateFootballPitch([FromBody] CreateFootballPitchRequest request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.DispatchAsync(new CreateFootballPitchCommand(request.Name ?? string.Empty), cancellationToken);
        return result.ToActionResult(true, $"/api/football-pitches/{result.Value.Id}");
    }
}

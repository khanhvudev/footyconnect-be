using FootyConnect.Application.Common;
using FootyConnect.Application.Common.Results;
using FootyConnect.Application.Users.DTOs;
using FootyConnect.Application.Users.Login;
using FootyConnect.Application.Users.Register;
using FootyConnect.WebAPI.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace FootyConnect.WebAPI.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(Dispatcher dispatcher) : ControllerBase  
{
    private readonly Dispatcher _dispatcher = dispatcher;

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Result<UserLoginDto>>> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.DispatchAsync(new LoginCommand(
            request.Email ?? string.Empty,
            request.Password ?? string.Empty), cancellationToken);

        return result.ToActionResult();
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Result<UserDto>>> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.DispatchAsync(new RegisterCommand(
            request.Email ?? string.Empty,
            request.Password ?? string.Empty), cancellationToken);

        return result.ToActionResult();
    }
}

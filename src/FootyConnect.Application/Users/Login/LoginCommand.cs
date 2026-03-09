using FootyConnect.Application.Abstractions.Commands;
using FootyConnect.Application.Users.DTOs;

namespace FootyConnect.Application.Users.Login;

public record LoginCommand(
    string Email,
    string Password) : ICommand<UserLoginDto>;

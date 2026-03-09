using FootyConnect.Application.Abstractions.Commands;
using FootyConnect.Application.Users.DTOs;

namespace FootyConnect.Application.Users.Register;

public record RegisterCommand(
    string Email,
    string Password) : ICommand<UserDto>;

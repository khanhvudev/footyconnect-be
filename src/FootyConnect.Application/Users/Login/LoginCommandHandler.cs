using FootyConnect.Application.Abstractions;
using FootyConnect.Application.Abstractions.Commands;
using FootyConnect.Application.Common.Results;
using FootyConnect.Application.Users.DTOs;
using FootyConnect.Domain.Entities;
using FootyConnect.Domain.Repositories;

namespace FootyConnect.Application.Users.Login;

public class LoginCommandHandler(
    IUserRepository userRepository, 
    IJwtProvider jwtProvider,
    IPasswordHasher passwordHasher) : ICommandHandler<LoginCommand, UserLoginDto>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;

    public async Task<Result<UserLoginDto>> HandleAsync(LoginCommand command, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetByEmailAsync(command.Email, cancellationToken);

        if (user is null)
        {
            return Result.Failure<UserLoginDto>(
                new Error(ErrorTypeConstant.NotFoundError, "User not found"));
        }

        bool verified = _passwordHasher.Verify(command.Password, user.PasswordHash);

        if (!verified)
        {
            return Result.Failure<UserLoginDto>(
                new Error(ErrorTypeConstant.UnauthorizedError, "Invalid credentials"));
        }

        string token = _jwtProvider.GenerateToken(user);

        return Result.Success(new UserLoginDto
        {
            User = user.ToDto(),
            AccessToken = token
        });
    }
}

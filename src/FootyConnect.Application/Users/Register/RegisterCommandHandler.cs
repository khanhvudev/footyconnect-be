using FootyConnect.Application.Abstractions;
using FootyConnect.Application.Abstractions.Commands;
using FootyConnect.Application.Common.Results;
using FootyConnect.Application.Users.DTOs;
using FootyConnect.Domain.Entities;
using FootyConnect.Domain.Enums;
using FootyConnect.Domain.Repositories;

namespace FootyConnect.Application.Users.Register;

public class RegisterCommandHandler(
    IRepository<User, Guid> repository,
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IUnitOfWork unitOfWork) : ICommandHandler<RegisterCommand, UserDto>
{
    private readonly IRepository<User, Guid> _repository = repository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<UserDto>> HandleAsync(RegisterCommand command, CancellationToken cancellationToken)
    {
        User? existingUser = await _userRepository.GetByEmailAsync(command.Email, cancellationToken); 

        if (existingUser is not null)
        {
            return Result.Failure<UserDto>(
                new Error(ErrorTypeConstant.ValidationError, "Email is already in use")); 
        } 

        string passwordHash = _passwordHasher.Hash(command.Password);  

        var user = new User
        {
            Email = command.Email,
            PasswordHash = passwordHash,
            UserRole = UserRole.NormalUser
        };

        await _repository.AddAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(user.ToDto());
    }
}

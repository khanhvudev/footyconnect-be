using FootyConnect.Domain.Entities;

namespace FootyConnect.Application.Abstractions;

public interface IJwtProvider
{
    string GenerateToken(User user);
}

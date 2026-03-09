using FootyConnect.Domain.Entities;

namespace FootyConnect.Application.Users.DTOs;

public static class UserDtoMappingConfiguration
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            UserRole = user.UserRole,
            Name = user.Name,
            PreferredPosition = user.PreferredPosition,
            SkillLevel = user.SkillLevel
        };
    }
}

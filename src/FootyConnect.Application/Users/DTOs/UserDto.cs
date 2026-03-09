using FootyConnect.Domain.Enums;

namespace FootyConnect.Application.Users.DTOs;

public class UserDto
{
    public Guid Id { get; set; }    
    public string Email { get; set; } = string.Empty;
    public UserRole UserRole { get; set; } = UserRole.NormalUser;
    public string? Name { get; set; }
    public string? PreferredPosition { get; set; }
    public SkillLevel? SkillLevel { get; set; }
}

using FootyConnect.Domain.Enums;

namespace FootyConnect.Domain.Entities;

public class User : Entity<Guid>
{
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public UserRole UserRole { get; set; } = UserRole.NormalUser;
    public string? Name { get; set; }
    public string? PreferredPosition { get; set; }
    public SkillLevel? SkillLevel { get; set; }
    public ICollection<Team> CaptainTeams { get; set; } = [];
    public ICollection<TeamMember> TeamMembers { get; set; } = [];
}

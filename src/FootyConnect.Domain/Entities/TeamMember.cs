using FootyConnect.Domain.Enums;

namespace FootyConnect.Domain.Entities;

public class TeamMember
{
    public Guid UserId { get; set; }
    public Guid TeamId { get; set; }
    public User User { get; set; } = null!;
    public Team Team { get; set; } = null!;
    public MemberRole MemberRole { get; set; } = MemberRole.Player;
}

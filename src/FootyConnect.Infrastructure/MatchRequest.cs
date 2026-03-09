using FootyConnect.Domain.Enums;

namespace FootyConnect.Domain.Entities;

public class MatchRequest : Entity<Guid>
{
    public Guid TimeSlotId { get; set; }
    public Guid RequestingTeamId { get; set; }
    public Guid FootballPitchId { get; set; }
    public MatchStatus Status { get; set; } = MatchStatus.Pending;
    public TimeSlot TimeSlot { get; set; } = null!;
    public Team RequestingTeam { get; set; } = null!;
    public FootballPitch FootballPitch { get; set; } = null!;   
}

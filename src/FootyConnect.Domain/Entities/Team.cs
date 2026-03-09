namespace FootyConnect.Domain.Entities;

public class Team : Entity<Guid>
{
    public Guid CaptainId { get; set; }
    public string Name { get; set; } = string.Empty;
    public User Captain { get; set; } = null!;
    public ICollection<TeamMember> TeamMembers { get; set; } = [];  
    public ICollection<TimeSlot> TimeSlots { get; set; } = [];
    public ICollection<MatchRequest> MatchRequests { get; set; } = [];
}

namespace FootyConnect.Domain.Entities;

public class TimeSlot : Entity<Guid>
{
    public Guid TeamId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Team Team { get; set; } = null!; 
    public ICollection<MatchRequest> MatchRequests { get; set; } = [];
}

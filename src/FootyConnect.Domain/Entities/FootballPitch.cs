namespace FootyConnect.Domain.Entities;

public class FootballPitch : Entity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public ICollection<MatchRequest> MatchRequests { get; set; } = [];
}

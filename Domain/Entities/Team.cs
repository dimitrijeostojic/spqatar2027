namespace Domain.Entities;

public class Team : Entity
{
    public required string TeamName { get; set; }
    public string? FlagIcon { get; set; }
    public required int GroupId { get; set; }
    public required Group Group { get; set; }

    public ICollection<Match> HomeMatches { get; set; } = [];
    public ICollection<Match> AwayMatches { get; set; } = [];

}

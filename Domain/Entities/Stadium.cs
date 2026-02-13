namespace Domain.Entities;

public class Stadium : Entity
{
    public required string StadiumName { get; set; }
    public required string City { get; set; }
    public required int Capacity { get; set; }
    public ICollection<Match> Matches { get; set; } = [];
}

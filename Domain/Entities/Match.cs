using Domain.Enums;

namespace Domain.Entities;

public class Match : Entity
{
    public required int HomeTeamId { get; set; }
    public required int AwayTeamId { get; set; }
    public required DateTime StartTime { get; set; }
    public required MatchStatusEnum Status { get; set; }
    public required int StadiumId { get; set; }
    public int? HomeGoals { get; set; }
    public int? AwayGoals { get; set; }
    public bool? IsForfeit { get; set; }
    public required Team HomeTeam { get; set; }
    public required Team AwayTeam { get; set; }
    public required Stadium Stadium { get; set; }
}

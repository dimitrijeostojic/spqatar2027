using Application.Common;
using Core;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.Team.Delete;

public sealed class DeleteTeamRequestHandler(ITeamRepository teamRepository)
    : IRequestHandler<DeleteTeamRequest, Result<DeleteTeamResponse>>
{
    private readonly ITeamRepository _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));

    public async Task<Result<DeleteTeamResponse>> Handle(DeleteTeamRequest request, CancellationToken cancellationToken)
    {
        var team = await _teamRepository.GetByPublicIdAsync(request.PublicId, cancellationToken);
        if (team is null)
        {
            return Result<DeleteTeamResponse>.Failure(ApplicationErrors.NotFound);
        }
        team = await _teamRepository.DeleteTeamAsync(team, cancellationToken);
        var response = new DeleteTeamResponse
        {
            TeamName = team.TeamName ?? string.Empty,
            FlagIcon = team.FlagIcon,
            GroupName = team.Group?.GroupName ?? string.Empty
        };
        return Result<DeleteTeamResponse>.Success(response);
    }
}

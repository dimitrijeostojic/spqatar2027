using Domain.Entities;

namespace Domain.RepositoryInterfaces;

public interface ITeamRepository
{
    Task AddAsync(Team team, CancellationToken cancellationToken = default);
    Task<List<Team>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Team?> GetByPublicIdAsync(Guid teamPublicId, CancellationToken cancellationToken);
    Task<Team> DeleteTeamAsync(Team team, CancellationToken cancellationToken);
}

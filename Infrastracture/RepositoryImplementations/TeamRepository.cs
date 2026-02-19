using Domain.Entities;
using Domain.RepositoryInterfaces;
using Infrastracture.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.RepositoryImplementations;

public sealed class TeamRepository(ApplicationDbContext dbContext) : ITeamRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task AddAsync(Team team, CancellationToken cancellationToken = default)
    {
        await _dbContext.Teams.AddAsync(team, cancellationToken);
    }

    public async Task<Team> DeleteTeamAsync(Team team, CancellationToken cancellationToken)
    {
        var item = _dbContext.Teams.Remove(team);
        return item.Entity;
    }

    public async Task<List<Team>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Teams.Include(x => x.Group).ToListAsync(cancellationToken);
    }

    public async Task<Team?> GetByPublicIdAsync(Guid teamPublicId, CancellationToken cancellationToken)
    {
        return await _dbContext.Teams.Include(x => x.Group).FirstOrDefaultAsync(x => x.PublicId == teamPublicId, cancellationToken);
    }
}

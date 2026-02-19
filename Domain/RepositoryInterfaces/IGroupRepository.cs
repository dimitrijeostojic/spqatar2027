using Domain.Entities;

namespace Domain.RepositoryInterfaces;

public interface IGroupRepository
{
    Task<List<Group>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Group?> GetByPublicIdAsync(Guid publicId, CancellationToken cancellationToken = default);
    Task CreateGroupAsync(Group group, CancellationToken cancellationToken);
    Task<Group?> DeleteGroupAsync(Guid publicId, CancellationToken cancellationToken);
}

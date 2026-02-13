using Core;
using Domain.Abstraction;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.Group.CreateGroup;

public sealed class CreateGroupRequestHandler(
    IGroupRepository groupRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateGroupRequest, Result<CreateGroupResponse>>
{
    private readonly IGroupRepository _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public async Task<Result<CreateGroupResponse>> Handle(CreateGroupRequest request, CancellationToken cancellationToken)
    {
        var createdGroup = Domain.Entities.Group.Create(request.groupName);
        await _groupRepository.CreateGroupAsync(createdGroup, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<CreateGroupResponse>.Success(new CreateGroupResponse() { PublicId = createdGroup.PublicId });
    }
}

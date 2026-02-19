using Application.Common;
using Core;
using Domain.Abstraction;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.Group.UpdateGroup;

public sealed class UpdateGroupRequestHandler(IGroupRepository groupRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateGroupRequest, Result<UpdateGroupResponse>>
{
    private readonly IGroupRepository _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public async Task<Result<UpdateGroupResponse>> Handle(UpdateGroupRequest request, CancellationToken cancellationToken)
    {
        var group = await _groupRepository.GetByPublicIdAsync(request.PublicId, cancellationToken);
        if (group is null)
        {
            return Result<UpdateGroupResponse>.Failure(ApplicationErrors.NotFound);
        }
        group.UpdateGroupName(request.Name);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var response = new UpdateGroupResponse
        {
            PublicId = group.PublicId,
            Name = group.GroupName ?? string.Empty
        };

        return Result<UpdateGroupResponse>.Success(response);

    }
}

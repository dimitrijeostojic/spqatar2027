using Application.Common;
using Core;
using Domain.Abstraction;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.Group.DeleteGroup;

public sealed class DeleteGroupRequestHandler(IGroupRepository groupRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteGroupRequest, Result<DeleteGroupResponse>>
{
    private readonly IGroupRepository _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public async Task<Result<DeleteGroupResponse>> Handle(DeleteGroupRequest request, CancellationToken cancellationToken)
    {
        var group = await _groupRepository.DeleteGroupAsync(request.PublicId, cancellationToken);
        if (group == null)
        {
            return Result<DeleteGroupResponse>.Failure(ApplicationErrors.NotFound);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var result = new DeleteGroupResponse
        {
            PublicId = group.PublicId,
            GroupName = group.GroupName
        };

        return Result<DeleteGroupResponse>.Success(result);
    }
}

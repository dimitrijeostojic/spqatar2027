using Application.Common;
using Core;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.Group.GetGroupById;

public sealed class GetGroupByIdRequestHandler(IGroupRepository groupRepository)
    : IRequestHandler<GetGroupByIdRequest, Result<GetGroupByIdResponse>>
{
    private readonly IGroupRepository _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));

    public async Task<Result<GetGroupByIdResponse>> Handle(GetGroupByIdRequest request, CancellationToken cancellationToken)
    {
        var group = await _groupRepository.GetByPublicIdAsync(request.PublicId, cancellationToken);
        if (group == null)
        {
            return Result<GetGroupByIdResponse>.Failure(ApplicationErrors.NotFound);
        }
        var response = new GetGroupByIdResponse()
        {
            GroupName = group.GroupName
        };

        return Result<GetGroupByIdResponse>.Success(response);
    }
}

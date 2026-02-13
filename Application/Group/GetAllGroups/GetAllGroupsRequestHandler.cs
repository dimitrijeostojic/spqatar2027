using Application.Common;
using Core;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.Group.GetAllGroups;

public sealed class GetAllGroupsRequestHandler(IGroupRepository groupRepository)
    : IRequestHandler<GetAllGroupsRequest, Result<GetAllGroupsResponse>>
{
    private readonly IGroupRepository _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));

    public async Task<Result<GetAllGroupsResponse>> Handle(GetAllGroupsRequest request, CancellationToken cancellationToken)
    {
        var groups = await _groupRepository.GetAllAsync(cancellationToken);
        if (groups is null)
        {
            return Result<GetAllGroupsResponse>.Failure(ApplicationErrors.NotFound);
        }
        var result = groups
           .Select(c => new GetAllGroupsDto
           {
               PublicId = c.PublicId,
               GroupName = c.GroupName
           })
           .ToList();

        return Result<GetAllGroupsResponse>.Success(new GetAllGroupsResponse(result));
    }
}

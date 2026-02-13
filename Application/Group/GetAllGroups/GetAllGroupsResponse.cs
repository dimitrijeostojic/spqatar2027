using Application.Common;

namespace Application.Group.GetAllGroups;

public sealed class GetAllGroupsResponse(ICollection<GetAllGroupsDto> items)
    : EntityCollectionResult<GetAllGroupsDto>(items)
{
}

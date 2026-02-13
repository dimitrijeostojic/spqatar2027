using Application.Common;

namespace Application.Group.GetAllGroups;

public sealed class GetAllGroupsDto : Dto
{
    public required string GroupName { get; set; }
}

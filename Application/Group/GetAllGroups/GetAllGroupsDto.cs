using Application.Common;
using Application.Team.GetAll;

namespace Application.Group.GetAllGroups;

public sealed class GetAllGroupsDto : Dto
{
    public required string GroupName { get; set; }
    public List<GetAllTeamsDto> Teams { get; set; } = [];
}

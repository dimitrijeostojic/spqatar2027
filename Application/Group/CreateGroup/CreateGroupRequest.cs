using Core;
using MediatR;

namespace Application.Group.CreateGroup;

public sealed record CreateGroupRequest(string groupName) : IRequest<Result<CreateGroupResponse>>
{
}

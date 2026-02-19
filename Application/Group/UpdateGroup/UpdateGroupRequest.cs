using Core;
using MediatR;

namespace Application.Group.UpdateGroup;

public sealed class UpdateGroupRequest
    : IRequest<Result<UpdateGroupResponse>>
{
    public required Guid PublicId { get; set; }
    public required string Name { get; set; }
}

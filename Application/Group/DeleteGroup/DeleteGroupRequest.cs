using Core;
using MediatR;

namespace Application.Group.DeleteGroup;

public sealed class DeleteGroupRequest
    : IRequest<Result<DeleteGroupResponse>>
{
    public required Guid PublicId { get; set; }

}

using Core;
using MediatR;

namespace Application.Group.GetGroupById;

public sealed record GetGroupByIdRequest(
    Guid PublicId
    ) : IRequest<Result<GetGroupByIdResponse>>
{
}

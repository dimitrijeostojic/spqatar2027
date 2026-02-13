using Core;
using MediatR;

namespace Application.Group.GetAllGroups;

public sealed record GetAllGroupsRequest()
    : IRequest<Result<GetAllGroupsResponse>>;

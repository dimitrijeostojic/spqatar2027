using Application.Group.CreateGroup;
using Application.Group.GetAllGroups;
using Application.Group.GetGroupById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPQatar2027.Common;

namespace SPQatar2027.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class GroupController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpGet]
    public async Task<IActionResult> GetAllGroups(CancellationToken cancellationToken)
    {
        var request = new GetAllGroupsRequest();
        var result = await _mediator.Send(request, cancellationToken);
        return result.ToActionResult();
    }

    [HttpGet("{publicId:Guid}")]
    public async Task<IActionResult> GetGroupById([FromRoute] Guid publicId, CancellationToken cancellationToken)
    {
        var request = new GetGroupByIdRequest(publicId);
        var result = await _mediator.Send(request, cancellationToken);
        return result.ToActionResult();
    }

    [HttpPost]
    public async Task<IActionResult> CreateGroup([FromBody] CreateGroupRequest createGroupRequest, CancellationToken cancellationToken)
    {
        var request = new CreateGroupRequest(createGroupRequest.groupName);
        var result = await _mediator.Send(request, cancellationToken);
        return result.ToActionResult();
    }
}

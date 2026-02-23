using Application.Stadium.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPQatar2027.Common;

namespace SPQatar2027.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class StadiumController : ControllerBase
{
    private readonly IMediator _mediator;

    public StadiumController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStadiums(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllStadiumsRequest(), cancellationToken);
        return result.ToActionResult();
    }
}
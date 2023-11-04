using Interview.Demo.Api.Extensions;
using Interview.Demo.Application.Endpoints.People;
using Interview.Demo.Application.Endpoints.People.Commands;
using Interview.Demo.Application.Endpoints.People.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Demo.Api.Controllers;

[ApiController]
[Route("api/people")]
public class PeopleController : ControllerBase
{
    private readonly IMediator _mediator;

    public PeopleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IEnumerable<PersonViewModel>> GetPeopleAsync([FromQuery] PeopleQuery request)
    {
        var result = await _mediator.Send(request);
        return result.Data;
    }

    //=>
    //(await _mediator.Send(request)).ToActionResult();

    [HttpPost]
    public async Task<ActionResult> AddPersonAsync([FromBody] AddPersonCommand command) =>
        (await _mediator.Send(command)).ToActionResult();
}

namespace BloodDonationManagement.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/users")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult> Post([FromBody] InsertUserCommand command)
    {
        await mediator.Send(command);
        return Created();
    }

    [HttpPut("{userId:guid}")]
    public async Task<ActionResult> Update([FromBody] UpdateUserCommand command)
    {
        var user = await mediator.Send(command);
        return Ok(user);
    }

    [HttpPut("{userId:guid}/update-password")]
    public async Task<ActionResult> UpdatePassword([FromBody] UpdateUserPasswordCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }
    
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult> Login([FromBody] LoginUserCommand command)
    {
        var token = await mediator.Send(command);
        return Ok(token.Data);
    }
}
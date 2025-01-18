namespace BloodDonationManagement.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/donors")]
public class DonorsController(IMediator mediator) : ControllerBase
{
    [HttpGet("donation-from-last-30-days")]
    [ProducesResponseType(typeof(ListDonationsFromLast30DaysReportDto), StatusCodes.Status200OK)]
    public async Task<ActionResult> ListDonationsFromLast30Days()
    {
        var donations = await mediator.Send(new ListDonationsFromLast30DaysReportQuery());
        return Ok(donations.Data);
    }

    [HttpGet("donations/{donorId:guid}")]
    [ProducesResponseType(typeof(ListDonationsDto), StatusCodes.Status200OK)]
    public async Task<ActionResult> ListDonations(Guid donorId)
    {
        var donations = await mediator.Send(new ListDonationsQuery(donorId));
        return Ok(donations.Data);
    }

    [HttpPost]
    [ProducesResponseType( StatusCodes.Status201Created)]
    public async Task<ActionResult> InsertDonor([FromBody] InsertDonorCommand command)
    {
        await mediator.Send(command);
        return Created();
    }

    [HttpPost("donation")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> InsertDonation([FromBody] InsertDonationCommand command)
    {
        await mediator.Send(command);
        return Created();
    }
}
﻿namespace BloodDonationManagement.WebApi.Controllers;

[ApiController]
[Route("api/donators")]
public class DonatorsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(ListDonationsFromLast30DaysReportDto), StatusCodes.Status200OK)]
    public async Task<ActionResult> ListDonationsFromLast30Days()
    {
        var donations = await mediator.Send(new ListDonationsFromLast30DaysReportQuery());
        return Ok(donations.Data);
    }

    [HttpGet("donations/donatorId:guid")]
    [ProducesResponseType(typeof(ListDonationsFromLast30DaysReportDto), StatusCodes.Status200OK)]
    public async Task<ActionResult> ListDonationsFromLast30Days(Guid donatorId)
    {
        var donations = await mediator.Send(new ListDonationsQuery(donatorId));
        return Ok(donations.Data);
    }

    [HttpPost]
    [ProducesResponseType( StatusCodes.Status201Created)]
    public async Task<ActionResult> InsertDonator([FromBody] InsertDonatorCommand command)
    {
        await mediator.Send(command);
        return Created();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> InsertDonation([FromBody] InsertDonationCommand command)
    {
        await mediator.Send(command);
        return Created();
    }
}
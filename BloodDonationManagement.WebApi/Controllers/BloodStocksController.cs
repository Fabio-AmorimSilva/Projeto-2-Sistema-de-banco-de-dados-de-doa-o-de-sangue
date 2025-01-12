namespace BloodDonationManagement.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/blood-stocks")]
public class BloodStocksController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDto<IEnumerable<BloodStockDto>>))]
    public async Task<ActionResult<IEnumerable<BloodStockDto>>> BloodStockReport()
    {
        var bloodStock = await mediator.Send(new BloodStockReportQuery());
        return Ok(bloodStock.Data);
    }
}
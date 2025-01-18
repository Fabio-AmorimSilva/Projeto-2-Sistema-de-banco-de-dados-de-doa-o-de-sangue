namespace BloodDonationManagement.Application.Queries.BloodStockReport;

public class BloodStockReportQueryHandler(IBloodStockRepository repository) : IRequestHandler<BloodStockReportQuery, Result<IEnumerable<BloodStockDto>>>
{
    public async Task<Result<IEnumerable<BloodStockDto>>> Handle(BloodStockReportQuery request, CancellationToken cancellationToken)
    {
        var bloodStocks = await repository.ListAsync();

        var bloodStockByType = bloodStocks
            .GroupBy(bt => new
            {
                bt.BloodType,
                bt.RhFactor
            })
            .Select(bt => new BloodStockDto
            {
                BloodType = bt.Key.BloodType,
                RhFactor = bt.Key.RhFactor,
                Quantity = bt.First().Quantity
            });
        
        return new Result<IEnumerable<BloodStockDto>>(bloodStockByType);
    }
}
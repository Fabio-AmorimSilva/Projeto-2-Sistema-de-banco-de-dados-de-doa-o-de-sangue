namespace BloodDonationManagement.Application.Queries.BloodStockReport;

public record BloodStockReportQuery : IRequest<ResultDto<IEnumerable<BloodStockDto>>>;
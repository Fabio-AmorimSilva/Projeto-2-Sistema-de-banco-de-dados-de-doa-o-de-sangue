﻿using BloodDonationManagement.Domain.Common;

namespace BloodDonationManagement.Application.Queries.BloodStockReport;

public record BloodStockReportQuery : IRequest<Result<IEnumerable<BloodStockDto>>>;
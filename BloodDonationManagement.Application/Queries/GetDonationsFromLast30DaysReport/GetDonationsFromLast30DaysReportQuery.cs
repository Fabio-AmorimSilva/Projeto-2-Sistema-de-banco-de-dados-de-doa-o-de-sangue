﻿namespace BloodDonationManagement.Application.Queries.GetDonationsFromLast30DaysReport;

public record GetDonationsFromLast30DaysReportQuery : IRequest<IEnumerable<ResultDto<DonationDto>>>;
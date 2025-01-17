﻿namespace BloodDonationManagement.Application.Queries.ListDonations;

public record ListDonationsQuery(Guid DonorId) : IRequest<ResultDto<ListDonationsDto>>;
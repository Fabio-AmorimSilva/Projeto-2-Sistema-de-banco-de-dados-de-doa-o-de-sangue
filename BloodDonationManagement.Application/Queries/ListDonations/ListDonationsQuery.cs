using BloodDonationManagement.Domain.Common;

namespace BloodDonationManagement.Application.Queries.ListDonations;

public record ListDonationsQuery(Guid DonorId) : IRequest<Result<ListDonationsDto>>;
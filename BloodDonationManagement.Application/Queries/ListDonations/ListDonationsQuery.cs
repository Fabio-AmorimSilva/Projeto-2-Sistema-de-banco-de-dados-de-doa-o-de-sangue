namespace BloodDonationManagement.Application.Queries.ListDonations;

public record ListDonationsQuery(Guid DonatorId) : IRequest<ResultDto<ListDonationsDto>>;
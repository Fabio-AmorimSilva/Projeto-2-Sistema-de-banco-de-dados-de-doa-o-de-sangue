namespace BloodDonationManagement.Application.Queries.GetDonation;

public record GetDonationQuery : IRequest<ResultDto<DonationDto>>;
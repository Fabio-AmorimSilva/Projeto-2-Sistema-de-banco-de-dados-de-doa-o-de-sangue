namespace BloodDonationManagement.Application.Queries.ListDonations;

public class ListDonationsQueryHandler(IDonatorRepository repository) : IRequestHandler<ListDonationsQuery, ResultDto<ListDonationsDto>>
{
    public async Task<ResultDto<ListDonationsDto>> Handle(ListDonationsQuery request, CancellationToken cancellationToken)
    {
        var donator = await repository.GetDonatorAndHisDonationsAsync(donatorId: request.DonatorId);

        if (donator is null)
            return ResultDto<ListDonationsDto>.Error(ErrorMessages.NotFound<Donator>());

        var donations = new ListDonationsDto
        {
            Donator = new DonatorDto
            {
                Email = donator.Email,
                Name = donator.Name,
                Weight = donator.Weight,
                Birth = donator.Birth,
                Gender = donator.Gender,
                RhFactor = donator.RhFactor,
                BloodType = donator.BloodType,
                Address = new ResponseAddressDto
                {
                    PublicArea = donator.Address.PublicArea,
                    City = donator.Address.City,
                    State = donator.Address.State,
                    Cep = donator.Address.Cep
                },
                Donations = donator.Donations.Select(donation => new DonationDto
                {
                    DonationDate = donation.DonationDate,
                    Quantity = donation.Quantity
                })
            }
        };

        return new ResultDto<ListDonationsDto>(donations);
    }
}
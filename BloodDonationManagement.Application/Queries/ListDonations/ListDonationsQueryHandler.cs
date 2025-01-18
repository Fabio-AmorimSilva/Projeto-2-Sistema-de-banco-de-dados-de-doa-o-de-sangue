using BloodDonationManagement.Domain.Common;

namespace BloodDonationManagement.Application.Queries.ListDonations;

public class ListDonationsQueryHandler(IDonorRepository repository) : IRequestHandler<ListDonationsQuery, Result<ListDonationsDto>>
{
    public async Task<Result<ListDonationsDto>> Handle(ListDonationsQuery request, CancellationToken cancellationToken)
    {
        var donor = await repository.GetDonorAndHisDonationsAsync(donorId: request.DonorId);

        if (donor is null)
            return Result<ListDonationsDto>.Error(ErrorMessages.NotFound<Donor>());

        var donations = new ListDonationsDto
        {
            Donator = new DonatorDto
            {
                Email = donor.Email,
                Name = donor.Name,
                Weight = donor.Weight,
                Birth = donor.Birth,
                Gender = donor.Gender,
                RhFactor = donor.RhFactor,
                BloodType = donor.BloodType,
                Address = new ResponseAddressDto
                {
                    PublicArea = donor.Address.PublicArea,
                    City = donor.Address.City,
                    State = donor.Address.State,
                    Cep = donor.Address.Cep
                },
                Donations = donor.Donations.Select(donation => new DonationDto
                {
                    DonationDate = donation.DonationDate,
                    Quantity = donation.Quantity
                })
            }
        };

        return new Result<ListDonationsDto>(donations);
    }
}
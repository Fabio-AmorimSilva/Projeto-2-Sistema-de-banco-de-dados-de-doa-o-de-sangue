namespace BloodDonationManagement.Application.Queries.ListDonationsFromLast30DaysReport;

public class ListDonationsFromLast30DaysReportQueryHandler(IDonorRepository repository)
    : IRequestHandler<ListDonationsFromLast30DaysReportQuery, Result<ListDonationsFromLast30DaysReportDto>>
{
    public async Task<Result<ListDonationsFromLast30DaysReportDto>> Handle(ListDonationsFromLast30DaysReportQuery request, CancellationToken cancellationToken)
    {
        var donors = await repository.GetAllDonationsFromLast30DaysAsync();

        var existsDonations = donors.SelectMany(d => d.Donations).Any();
        
        if (existsDonations)
            return new Result<ListDonationsFromLast30DaysReportDto>();
        
        var donations = new ListDonationsFromLast30DaysReportDto
        {
            Donators = donors.Select(donor => new DonorDto
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
            })
        };
        
        return new Result<ListDonationsFromLast30DaysReportDto>(donations);
    }
}
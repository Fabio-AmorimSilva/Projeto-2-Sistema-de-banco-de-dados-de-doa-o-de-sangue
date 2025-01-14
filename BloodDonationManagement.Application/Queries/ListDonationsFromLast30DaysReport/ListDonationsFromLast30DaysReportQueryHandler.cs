namespace BloodDonationManagement.Application.Queries.ListDonationsFromLast30DaysReport;

public class ListDonationsFromLast30DaysReportQueryHandler(IDonatorRepository repository)
    : IRequestHandler<ListDonationsFromLast30DaysReportQuery, ResultDto<ListDonationsFromLast30DaysReportDto>>
{
    public async Task<ResultDto<ListDonationsFromLast30DaysReportDto>> Handle(ListDonationsFromLast30DaysReportQuery request, CancellationToken cancellationToken)
    {
        var donators = await repository.GetAllDonationsFromLast30DaysAsync();

        var existsDonations = donators.SelectMany(d => d.Donations).Any();
        
        if (existsDonations)
            return new ResultDto<ListDonationsFromLast30DaysReportDto>();
        
        var donations = new ListDonationsFromLast30DaysReportDto
        {
            Donators = donators.Select(donator => new DonatorDto
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
            })
        };
        
        return new ResultDto<ListDonationsFromLast30DaysReportDto>(donations);
    }
}
namespace BloodDonationManagement.Application.Commands.InsertDonation;

public class InsertDonationCommandHandler(
    IDonatorRepository repository,
    IMediator mediator
) : IRequestHandler<InsertDonationCommand, ResultDto>
{
    public async Task<ResultDto> Handle(InsertDonationCommand request, CancellationToken cancellationToken)
    {
        var donator = await repository.GetDonatorAndHisDonationsAsync(request.DonatorId);
        
        if (donator is null)
            return ResultDto.Error(ErrorMessages.NotFound<Donator>());

        var donation = new Donation(
            donator: donator,
            donationDate: request.DonationDate,
            quantity: request.Quantity
        );
        
        donator.AddDonation(donation);
        
        await repository.AddDonationAsync(donation);
        
        var @event = new BloodStockUpdatedEvent
        {
            BloodType = donator.BloodType,
            RhFactor = donator.RhFactor,
            Quantity = request.Quantity
        };

        await mediator.Publish(@event, cancellationToken);
        
        return ResultDto.Success();
    }
}
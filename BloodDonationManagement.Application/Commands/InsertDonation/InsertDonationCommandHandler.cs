﻿namespace BloodDonationManagement.Application.Commands.InsertDonation;

public class InsertDonationCommandHandler(
    IDonorRepository repository,
    IMediator mediator
) : IRequestHandler<InsertDonationCommand, Result>
{
    public async Task<Result> Handle(InsertDonationCommand request, CancellationToken cancellationToken)
    {
        var donor = await repository.GetDonorAndHisDonationsAsync(request.DonorId);
        
        if (donor is null)
            return Result.Error(ErrorMessages.NotFound<Donor>());

        var donation = new Donation(
            donor: donor,
            donationDate: request.DonationDate,
            quantity: request.Quantity
        );
        
        var result = donor.AddDonation(donation);
        
        if(!result.IsSuccess)
            return result;
        
        await repository.AddDonationAsync(donation);
        
        var @event = new BloodStockUpdatedEvent
        {
            BloodType = donor.BloodType,
            RhFactor = donor.RhFactor,
            Quantity = request.Quantity
        };

        await mediator.Publish(@event, cancellationToken);
        
        return Result.Success();
    }
}
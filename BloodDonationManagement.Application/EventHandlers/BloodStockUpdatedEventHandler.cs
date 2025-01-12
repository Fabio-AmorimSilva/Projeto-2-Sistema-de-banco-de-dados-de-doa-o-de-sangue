namespace BloodDonationManagement.Application.EventHandlers;

public class BloodStockUpdatedEventHandler(IBloodStockRepository repository) : INotificationHandler<BloodStockUpdatedEvent>
{
    public async Task Handle(BloodStockUpdatedEvent notification, CancellationToken cancellationToken)
    {
        var bloodStock = await repository.GetAsync(
            rhFactor: notification.RhFactor,
            bloodType: notification.BloodType
        );

        if (bloodStock is null)
            return;
        
        bloodStock.AddQuantity(notification.Quantity);
        
        await repository.UpdateAsync(bloodStock);
    }
}
namespace BloodDonationManagement.Application.BackgroundServices;

public class BloodStockQuantityNotificationService(
    ILogger<BloodStockQuantityNotificationService> logger,
    IBloodStockRepository repository
) : BackgroundService
{
    private async Task ShowBloodStockQuantityNotification()
    {
        const int bloodStockMinimumQuantity = BloodStock.MinimumBloodInStock;
        var bloodStockQuantity = await repository.VerifyStockAsync();

        if (bloodStockQuantity < bloodStockMinimumQuantity)
            logger.LogInformation($@"
                Blood stock quantity reached the minimum: {bloodStockMinimumQuantity}ml
                Blood stock quantity reached: {bloodStockQuantity}    
            ");
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await ShowBloodStockQuantityNotification();
            await Task.Delay(1000, stoppingToken);
        }
    }
}
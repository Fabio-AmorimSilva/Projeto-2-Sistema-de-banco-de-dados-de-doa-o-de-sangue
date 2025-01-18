namespace BloodDonationManagement.Domain.Tests.Entities;

public class BloodStockTests
{
    [Fact]
    public void ShouldThrowArgumentNullExceptionWhenBloodStockQuantityIsDefault()
    {
        var action = () => new BloodStock(
            bloodType: BloodType.A, 
            rhFactor: RhFactor.Negative, 
            quantity: 0
        );

        action.Should().Throw<ArgumentException>()
            .WithParameterName("quantity");
    }
}
namespace BloodDonationManagement.Application.Tests.Commands;

public class InsertDonationCommandTests
{
    [Theory]
    [MemberData(nameof(SimulationInsertDonationCommand))]
    public void ShouldReturnErrorWhenValidationFails(InsertDonationCommand command,
        string expectedErrorMessage
    )
    {
        var errorMessage = new InsertDonationCommandValidator().Validate(command);

        errorMessage.IsValid.Should().BeFalse();
        errorMessage.Errors.Should().HaveCount(1);
        errorMessage.Errors[0].ErrorMessage.Should().Be(expectedErrorMessage);
    }

    public static TheoryData<InsertDonationCommand, string> SimulationInsertDonationCommand()
    {
        return new TheoryData<InsertDonationCommand, string>
        {
            {
                new InsertDonationCommand(
                    DonorId: Guid.Empty,
                    DonationDate: DateTime.Now,
                    Quantity: 1
                ),
                ErrorMessages.CannotBeEmpty(nameof(InsertDonationCommand.DonorId))
            },
            {
                new InsertDonationCommand(
                    DonorId: Guid.NewGuid(),
                    DonationDate: DateTime.MinValue,
                    Quantity: 1
                ),
                ErrorMessages.CannotBeEmpty(nameof(InsertDonationCommand.DonationDate))
            },
            {
                new InsertDonationCommand(
                    DonorId: Guid.NewGuid(),
                    DonationDate: DateTime.Now,
                    Quantity: 0
                ),
                ErrorMessages.CannotBeEmpty(nameof(InsertDonationCommand.Quantity))
            }
        };
    }
}
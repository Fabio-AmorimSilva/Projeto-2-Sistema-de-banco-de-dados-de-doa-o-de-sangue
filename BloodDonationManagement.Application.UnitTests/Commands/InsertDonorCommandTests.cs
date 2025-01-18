namespace BloodDonationManagement.Application.Tests.Commands;

public class InsertDonorCommandTests
{
    [Theory]
    [MemberData(nameof(SimulationInsertDonationCommand))]
    public void ShouldReturnErrorWhenValidationFails(InsertDonorCommand command,
        string expectedErrorMessage
    )
    {
        var errorMessage = new InsertDonorCommandValidator().Validate(command);

        errorMessage.IsValid.Should().BeFalse();
        errorMessage.Errors.Should().HaveCount(1);
        errorMessage.Errors[0].ErrorMessage.Should().Be(expectedErrorMessage);
    }

    public static TheoryData<InsertDonorCommand, string> SimulationInsertDonationCommand()
    {
        return new TheoryData<InsertDonorCommand, string>
        {
            {
                new InsertDonorCommand(
                    Name: string.Empty,
                    Email: "teste@teste.com",
                    Birth: DateTime.Now,
                    Gender: Gender.Male,
                    Weight: 1,
                    BloodType: BloodType.A,
                    RhFactor: RhFactor.Negative,
                    Cep: "000000"
                ),
                ErrorMessages.CannotBeEmpty(nameof(InsertDonorCommand.Name))
            },
            {
                new InsertDonorCommand(
                    Name: "teste",
                    Email: string.Empty,
                    Birth: DateTime.Now,
                    Gender: Gender.Male,
                    Weight: 1,
                    BloodType: BloodType.A,
                    RhFactor: RhFactor.Negative,
                    Cep: "000000"
                ),
                ErrorMessages.CannotBeEmpty(nameof(InsertDonorCommand.Email))
            },
            {
                new InsertDonorCommand(
                    Name: "teste",
                    Email: "teste@teste.com",
                    Birth: DateTime.MinValue,
                    Gender: Gender.Male,
                    Weight: 1,
                    BloodType: BloodType.A,
                    RhFactor: RhFactor.Negative,
                    Cep: "000000"
                ),
                ErrorMessages.CannotBeEmpty(nameof(InsertDonorCommand.Birth))
            },
            {
                new InsertDonorCommand(
                    Name: "teste",
                    Email: "teste@teste.com",
                    Birth: DateTime.Now,
                    Gender: (Gender)3,
                    Weight: 1,
                    BloodType: BloodType.A,
                    RhFactor: RhFactor.Negative,
                    Cep: "000000"
                ),
                ErrorMessages.CannotBeEmpty(nameof(InsertDonorCommand.Gender))
            },
            {
                new InsertDonorCommand(
                    Name: "teste",
                    Email: "teste@teste.com",
                    Birth: DateTime.Now,
                    Gender: Gender.Male,
                    Weight: 0,
                    BloodType: BloodType.A,
                    RhFactor: RhFactor.Negative,
                    Cep: "000000"
                ),
                ErrorMessages.CannotBeEmpty(nameof(InsertDonorCommand.Weight))
            },
            {
                new InsertDonorCommand(
                    Name: "teste",
                    Email: "teste@teste.com",
                    Birth: DateTime.Now,
                    Gender: Gender.Male,
                    Weight: 1,
                    BloodType: (BloodType)10,
                    RhFactor: RhFactor.Negative,
                    Cep: "000000"
                ),
                ErrorMessages.CannotBeEmpty(nameof(InsertDonorCommand.BloodType))
            },
            {
                new InsertDonorCommand(
                    Name: "teste",
                    Email: "teste@teste.com",
                    Birth: DateTime.Now,
                    Gender: Gender.Male,
                    Weight: 1,
                    BloodType: BloodType.A,
                    RhFactor: (RhFactor)10,
                    Cep: "000000"
                ),
                ErrorMessages.CannotBeEmpty(nameof(InsertDonorCommand.RhFactor))
            },
            {
                new InsertDonorCommand(
                    Name: "teste",
                    Email: "teste@teste.com",
                    Birth: DateTime.Now,
                    Gender: Gender.Male,
                    Weight: 1,
                    BloodType: BloodType.A,
                    RhFactor: RhFactor.Negative,
                    Cep: string.Empty
                ),
                ErrorMessages.CannotBeEmpty(nameof(InsertDonorCommand.Cep))
            }
        };
    }
}
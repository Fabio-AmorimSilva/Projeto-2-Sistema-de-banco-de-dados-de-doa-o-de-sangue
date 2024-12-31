namespace BloodDonationManagement.Application.Commands.InsertDonator;

public record InsertDonatorCommand(
    string DonatorId,
    DateTime DonationDate,
    string Quantity
) : IRequest;

public class InsertDonatorCommandValidator : AbstractValidator<InsertDonatorCommand>
{
    public InsertDonatorCommandValidator()
    {
        RuleFor(command => command.DonatorId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonatorCommand.DonatorId)));
        
        RuleFor(command => command.DonationDate)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonatorCommand.DonationDate)));
        
        RuleFor(command => command.Quantity)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonatorCommand.Quantity)));
    }
}
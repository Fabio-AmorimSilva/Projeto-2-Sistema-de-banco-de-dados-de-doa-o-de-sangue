namespace BloodDonationManagement.Application.Commands.InsertDonation;

public record InsertDonationCommand(
    string DonatorId,
    DateTime DonationDate,
    string Quantity
) : IRequest;

public class InsertDonationCommandValidator : AbstractValidator<InsertDonationCommand>
{
    public InsertDonationCommandValidator()
    {
        RuleFor(command => command.DonatorId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonationCommand.DonatorId)));
        
        RuleFor(command => command.DonationDate)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonationCommand.DonationDate)));
        
        RuleFor(command => command.Quantity)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonationCommand.Quantity)));
    }
}
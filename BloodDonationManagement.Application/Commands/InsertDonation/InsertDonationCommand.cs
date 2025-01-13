namespace BloodDonationManagement.Application.Commands.InsertDonation;

public record InsertDonationCommand(
    Guid DonatorId,
    DateTime DonationDate,
    int Quantity
) : IRequest<ResultDto>;

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
namespace BloodDonationManagement.Application.Commands.InsertDonation;

public record InsertDonationCommand(
    Guid DonorId,
    DateTime DonationDate,
    int Quantity
) : IRequest<ResultDto>;

public class InsertDonationCommandValidator : AbstractValidator<InsertDonationCommand>
{
    public InsertDonationCommandValidator()
    {
        RuleFor(command => command.DonorId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonationCommand.DonorId)));
        
        RuleFor(command => command.DonationDate)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonationCommand.DonationDate)));
        
        RuleFor(command => command.Quantity)
            .Must(quantity => quantity > 0)
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonationCommand.Quantity)));
    }
}
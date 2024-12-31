namespace BloodDonationManagement.Application.Commands.InsertDonation;

public record InsertDonationCommand(
    string Name,
    string Email,
    DateTime Birth,
    Gender Gender,
    double Weight,
    BloodType BloodType,
    RhFactor RhFactor,
    InputAddressDto InputAddress
) : IRequest;

public class InsertDonationCommandValidator : AbstractValidator<InsertDonationCommand>
{
    public InsertDonationCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonationCommand.Name)));

        RuleFor(command => command.Email)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonationCommand.Email)));

        RuleFor(command => command.Birth)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonationCommand.Birth)));

        RuleFor(command => command.Gender)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonationCommand.Gender)));

        RuleFor(command => command.Weight)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonationCommand.Weight)));

        RuleFor(command => command.BloodType)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonationCommand.BloodType)));

        RuleFor(command => command.RhFactor)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonationCommand.RhFactor)));

        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonationCommand.Name)));

        RuleFor(command => command.InputAddress)
            .SetValidator(new AddressDtoValidator());
    }
}
namespace BloodDonationManagement.Application.Commands.InsertDonator;

public record InsertDonatorCommand(
    string Name,
    string Email,
    DateTime Birth,
    Gender Gender,
    double Weight,
    BloodType BloodType,
    RhFactor RhFactor,
    string Cep
) : IRequest;

public class InsertDonationCommandValidator : AbstractValidator<InsertDonatorCommand>
{
    public InsertDonationCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonatorCommand.Name)));

        RuleFor(command => command.Email)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonatorCommand.Email)));

        RuleFor(command => command.Birth)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonatorCommand.Birth)));

        RuleFor(command => command.Gender)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonatorCommand.Gender)));

        RuleFor(command => command.Weight)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonatorCommand.Weight)));

        RuleFor(command => command.BloodType)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonatorCommand.BloodType)));

        RuleFor(command => command.RhFactor)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonatorCommand.RhFactor)));

        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonatorCommand.Name)));

        RuleFor(command => command.Cep)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonatorCommand.Cep)));
    }
}
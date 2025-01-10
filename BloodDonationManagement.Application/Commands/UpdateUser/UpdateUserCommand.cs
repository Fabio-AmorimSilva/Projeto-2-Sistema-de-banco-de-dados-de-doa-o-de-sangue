namespace BloodDonationManagement.Application.Commands.UpdateUser;

public record UpdateUserCommand(
    string Name,
    string Email
) : IRequest;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateUserCommand.Name)));

        RuleFor(command => command.Email)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateUserCommand.Email)));
    }
}
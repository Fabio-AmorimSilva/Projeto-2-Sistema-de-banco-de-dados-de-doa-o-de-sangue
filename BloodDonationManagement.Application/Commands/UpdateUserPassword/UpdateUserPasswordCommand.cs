namespace BloodDonationManagement.Application.Commands.UpdateUserPassword;

public record UpdateUserPasswordCommand(string Password) : IRequest;

public class UpdateUserPasswordCommandValidator : AbstractValidator<UpdateUserPasswordCommand>
{
    public UpdateUserPasswordCommandValidator()
    {
        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateUserPasswordCommand.Password)));
    }
}
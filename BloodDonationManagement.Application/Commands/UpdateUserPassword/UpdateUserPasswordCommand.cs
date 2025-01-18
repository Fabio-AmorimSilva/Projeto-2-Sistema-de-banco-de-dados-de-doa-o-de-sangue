using BloodDonationManagement.Domain.Common;

namespace BloodDonationManagement.Application.Commands.UpdateUserPassword;

public record UpdateUserPasswordCommand(
    Guid Id,
    string Password
) : IRequest<Result<string>>;

public class UpdateUserPasswordCommandValidator : AbstractValidator<UpdateUserPasswordCommand>
{
    public UpdateUserPasswordCommandValidator()
    {
        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateUserPasswordCommand.Password)));
    }
}
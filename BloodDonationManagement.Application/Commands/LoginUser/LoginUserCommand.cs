using BloodDonationManagement.Domain.Common;

namespace BloodDonationManagement.Application.Commands.LoginUser;

public record LoginUserCommand(
    string Email, 
    string Password
) : IRequest<Result<string>>;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(command => command.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(LoginUserCommand.Email)));
        
        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(LoginUserCommand.Password)));
    }
}
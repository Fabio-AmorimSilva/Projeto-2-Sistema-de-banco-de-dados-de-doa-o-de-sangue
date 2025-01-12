namespace BloodDonationManagement.Application.Commands.InsertUser;

public record InsertUserCommand(
    string Name,
    string Email,
    string Password
) : IRequest;

public class InsertUserCommandValidator : AbstractValidator<InsertUserCommand>
{
    public InsertUserCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertUserCommand.Name)));
        
        RuleFor(command => command.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertUserCommand.Email)));
        
        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertUserCommand.Name)));
    }
}
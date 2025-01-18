namespace BloodDonationManagement.Application.Commands.UpdateUser;

public record UpdateUserCommand(
    Guid Id,
    string Name,
    string Email
) : IRequest<Result<string>>;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateUserCommand.Id)));
        
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateUserCommand.Name)));
        
        RuleFor(command => command.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateUserCommand.Email)));
    }
}
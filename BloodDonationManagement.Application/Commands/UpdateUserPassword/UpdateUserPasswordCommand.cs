﻿namespace BloodDonationManagement.Application.Commands.UpdateUserPassword;

public record UpdateUserPasswordCommand(
    Guid Id,
    string Password
) : IRequest<ResultDto<string>>;

public class UpdateUserPasswordCommandValidator : AbstractValidator<UpdateUserPasswordCommand>
{
    public UpdateUserPasswordCommandValidator()
    {
        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateUserPasswordCommand.Password)));
    }
}
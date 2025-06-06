﻿namespace BloodDonationManagement.Application.Commands.InsertDonor;

public record InsertDonorCommand(
    string Name,
    string Email,
    DateTime Birth,
    Gender Gender,
    double Weight,
    BloodType BloodType,
    RhFactor RhFactor,
    string Cep
) : IRequest;

public class InsertDonorCommandValidator : AbstractValidator<InsertDonorCommand>
{
    public InsertDonorCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonorCommand.Name)));

        RuleFor(command => command.Email)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonorCommand.Email)));

        RuleFor(command => command.Birth)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonorCommand.Birth)));

        RuleFor(command => command.Gender)
            .IsInEnum()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonorCommand.Gender)));

        RuleFor(command => command.Weight)
            .Must(quantity => quantity > 0)
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonorCommand.Weight)));

        RuleFor(command => command.BloodType)
            .IsInEnum()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonorCommand.BloodType)));

        RuleFor(command => command.RhFactor)
            .IsInEnum()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonorCommand.RhFactor)));

        RuleFor(command => command.Cep)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InsertDonorCommand.Cep)));
    }
}
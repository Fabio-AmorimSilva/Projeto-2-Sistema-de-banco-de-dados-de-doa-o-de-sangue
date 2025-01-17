﻿namespace BloodDonationManagement.Application.Commands.InsertDonor;

public record InputAddressDto(
    string PublicArea,
    string City,
    string State,
    string Cep
);

public class InputAddressDtoValidator : AbstractValidator<InputAddressDto>
{
    public InputAddressDtoValidator()
    {
        RuleFor(dto => dto.PublicArea)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InputAddressDto.PublicArea)));
        
        RuleFor(dto => dto.City)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InputAddressDto.City)));
        
        RuleFor(dto => dto.State)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InputAddressDto.State)));
        
        RuleFor(dto => dto.Cep)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(InputAddressDto.Cep)));
    }
}
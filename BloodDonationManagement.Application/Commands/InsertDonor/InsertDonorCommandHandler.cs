namespace BloodDonationManagement.Application.Commands.InsertDonor;

public class InsertDonorCommandHandler(
    IDonorRepository repository,
    IGetAddressViaCepService service,
    IAiService aiService
) : IRequestHandler<InsertDonorCommand>
{
    public async Task Handle(InsertDonorCommand request, CancellationToken cancellationToken)
    {
        var address = await service.GetAddressViaCep(request.Cep);
        var complement = await aiService.Create(
            systemPrompt: $"Detailed information about the city {address.Data.City}",
            userPrompt: address.Data.Cep
        );

        var donor = new Donor(
            name: request.Name,
            email: request.Email,
            birth: request.Birth,
            gender: request.Gender,
            weight: request.Weight,
            bloodType: request.BloodType,
            rhFactor: request.RhFactor,
            address: new Address(
                publicArea: address.Data!.PublicArea,
                city: address.Data.City,
                state: address.Data.State,
                cep: address.Data.Cep,
                complement: complement
            )
        );

        await repository.AddAsync(donor);
    }
}
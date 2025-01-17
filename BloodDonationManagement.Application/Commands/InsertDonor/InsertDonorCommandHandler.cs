namespace BloodDonationManagement.Application.Commands.InsertDonator;

public class InsertDonorCommandHandler(
    IDonorRepository repository,
    GetAddressViaCepService service
) : IRequestHandler<InsertDonorCommand>
{
    public async Task Handle(InsertDonorCommand request, CancellationToken cancellationToken)
    {
        var address = await service.GetAddressViaCep(request.Cep);

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
                cep: address.Data.Cep
            )
        );

        await repository.AddAsync(donor);
    }
}
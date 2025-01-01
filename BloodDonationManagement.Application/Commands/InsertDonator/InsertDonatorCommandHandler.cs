namespace BloodDonationManagement.Application.Commands.InsertDonator;

public class InsertDonatorCommandHandler(
    IDonatorRepository repository,
    IUnitOfWork unitOfWork,
    GetAddressViaCepService service
) : IRequestHandler<InsertDonatorCommand>
{
    public async Task Handle(InsertDonatorCommand request, CancellationToken cancellationToken)
    {
        var address = await service.GetAddressViaCep(request.Cep);

        var donator = new Donator(
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

        await repository.AddAsync(donator);
        await unitOfWork.Commit();
    }
}
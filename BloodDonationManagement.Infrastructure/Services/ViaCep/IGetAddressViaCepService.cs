namespace BloodDonationManagement.Infrastructure.Services.ViaCep;

public interface IGetAddressViaCepService
{
    Task<Result<ResponseAddressDto>> GetAddressViaCep(string cep);
}
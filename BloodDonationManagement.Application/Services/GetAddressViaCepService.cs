using BloodDonationManagement.Domain.Common;

namespace BloodDonationManagement.Application.Services;

public class GetAddressViaCepService
{
    public async Task<Result<ResponseAddressDto>> GetAddressViaCep(string cep)
    {
        var httpClient = new HttpClient();
        
        var response = await httpClient.GetFromJsonAsync<GetAddressViaCepDto>(requestUri: $"https://viacep.com.br/ws/{cep}/json/");

        if (response is null)
            return Result<ResponseAddressDto>.Error(ErrorMessages.NotFound<Address>());
        
        var address = new ResponseAddressDto
        {
            PublicArea = response.Logradouro,
            Cep = response.Cep,
            City = response.Localidade,
            State = response.Estado
        };
        
        return new Result<ResponseAddressDto>(address);
    }
}
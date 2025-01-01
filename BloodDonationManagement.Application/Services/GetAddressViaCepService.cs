namespace BloodDonationManagement.Application.Services;

public class GetAddressViaCepService
{
    public async Task<ResultDto<ResponseAddressDto>> GetAddressViaCep(string cep)
    {
        var httpClient = new HttpClient();
        
        var response = await httpClient.GetFromJsonAsync<GetAddressViaCepDto>(requestUri: $"https://viacep.com.br/ws/{cep}/json/");

        if (response is null)
            return ResultDto<ResponseAddressDto>.Error(ErrorMessages.NotFound<Address>());
        
        var address = new ResponseAddressDto
        {
            PublicArea = response.Logradouro,
            Cep = response.Cep,
            City = response.Localidade,
            State = response.Estado
        };
        
        return new ResultDto<ResponseAddressDto>(address);
    }
}
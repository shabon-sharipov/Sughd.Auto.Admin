using System.Net;
using System.Net.Http.Json;
using Sughd.Auto.Admin.AuthService.Utility;
using Sughd.Auto.Admin.Services.HelperModels;
using Sughd.Auto.Admin.Services.RequestModels;
using Sughd.Auto.Admin.Services.ResponseModels;

namespace Sughd.Auto.Admin.Services;

public interface ICarService
{
    Task<HttpStatusCode> Post(CarRequestModel carRequestModel, CustomAuthenticationStateProvider authenticationStateProvider);
    Task<List<CarResponseModels> ?> Get(int pageSize, int offSet);
    Task Update(long carId, CarRequestModel carRequestModel, CustomAuthenticationStateProvider authenticationStateProvider);
    Task<int> UploadImageFile(long id, MultipartFormDataContent content, CustomAuthenticationStateProvider authenticationStateProvider);
}

public class CarService : ICarService
{
    private HttpClient _httpClient;

    public CarService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpStatusCode> Post(CarRequestModel carRequestModel, CustomAuthenticationStateProvider authenticationStateProvider)
    {
        SetToke.SetTokeToHeaderRequest(_httpClient, await authenticationStateProvider.GetToken());
        var responseMessage = await _httpClient.PostAsJsonAsync("Car", carRequestModel);
        return responseMessage.StatusCode;
    }

    public async Task<List<CarResponseModels> ?> Get(int pageSize, int offSet)
    {
        return await _httpClient.GetFromJsonAsync<List<CarResponseModels>>(
            $"Car/GetAll?pageSize={pageSize}&offSet={offSet}");
    }

    public async Task Update(long carId, CarRequestModel carRequestModel, CustomAuthenticationStateProvider authenticationStateProvider)
    {
        SetToke.SetTokeToHeaderRequest(_httpClient, await authenticationStateProvider.GetToken());
        await _httpClient.PutAsJsonAsync($"Car?id={carId}", carRequestModel);
    }
    
    public async Task<int> UploadImageFile(long id, MultipartFormDataContent content, CustomAuthenticationStateProvider authenticationStateProvider)
    {
        SetToke.SetTokeToHeaderRequest(_httpClient, await authenticationStateProvider.GetToken());
        var response = await _httpClient.PutAsync($"Car/UpdateImage?id={id}", content);

        return await response.Content.ReadFromJsonAsync<int>();
    }
}
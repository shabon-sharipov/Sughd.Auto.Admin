using System.Net.Http.Json;
using System.Text.Json;
using Sughd.Auto.Admin.AuthService.Utility;
using Sughd.Auto.Admin.Services.HelperModels;
using Sughd.Auto.Admin.Services.RequestModels;
using Sughd.Auto.Admin.Services.ResponseModels;

namespace Sughd.Auto.Admin.Services;

public interface ICarService
{
    Task<List<CarResponseModels> ?> Search(SearchCarRequestModel carRequestModel);
    Task<CarResponseModels ?> Post(CarRequestModel carRequestModel, CustomAuthenticationStateProvider authenticationStateProvider);
    Task<List<CarResponseModels> ?> Get(int pageSize, int offSet);
    Task UpdatePaymentAt(long carId, CustomAuthenticationStateProvider authenticationStateProvider);
    Task<CalculateCheckResponseModel> CalculateCheck(CalculateCheckRequestModel calculateCheckResponseModel, CustomAuthenticationStateProvider authenticationStateProvider);
    Task Update(long carId, CarRequestModel carRequestModel, CustomAuthenticationStateProvider authenticationStateProvider);
    Task<int> UploadImageFile(long id, MultipartFormDataContent content, CustomAuthenticationStateProvider authenticationStateProvider);

    Task UpdateStatus(long carId, bool isActive, CustomAuthenticationStateProvider authenticationStateProvider);
    Task DeleteCar(long carId, CustomAuthenticationStateProvider authenticationStateProvider);
    Task<CarStatisticsResponseModel> GetStatistics(CustomAuthenticationStateProvider authenticationStateProvider);
}

public class CarService : ICarService
{
    private HttpClient _httpClient;

    public CarService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<CarResponseModels> ?> Search(SearchCarRequestModel carRequestModel)
    {
        var response = await _httpClient.PostAsJsonAsync("Search", carRequestModel);

        var loginResult = JsonSerializer.Deserialize<List<CarResponseModels>>(await response.Content.ReadAsStringAsync(),
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return loginResult;
    }

    public async Task<CarResponseModels ?> Post(CarRequestModel carRequestModel, CustomAuthenticationStateProvider authenticationStateProvider)
    {
        SetToke.SetTokeToHeaderRequest(_httpClient, await authenticationStateProvider.GetToken());
        var response = await _httpClient.PostAsJsonAsync("Car", carRequestModel);
       
        var loginResult = JsonSerializer.Deserialize<CarResponseModels>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return loginResult;
    }

    public async Task<List<CarResponseModels> ?> Get(int pageSize, int offSet)
    {
        return await _httpClient.GetFromJsonAsync<List<CarResponseModels>>(
            $"Car/GetAll?pageSize={pageSize}&offSet={offSet}");
    }

    public async Task UpdatePaymentAt(long carId, CustomAuthenticationStateProvider authenticationStateProvider)
    {
        SetToke.SetTokeToHeaderRequest(_httpClient, await authenticationStateProvider.GetToken());
        await _httpClient.PutAsJsonAsync($"Car/UpdatePaymentAt?carId={carId}", carId);
    }

    public async Task<CalculateCheckResponseModel> CalculateCheck(CalculateCheckRequestModel calculateCheckResponseModel,
        CustomAuthenticationStateProvider authenticationStateProvider)
    {
        //SetToke.SetTokeToHeaderRequest(_httpClient, await authenticationStateProvider.GetToken());
        var response = await _httpClient.GetFromJsonAsync<CalculateCheckResponseModel>(
                           $"Car/CalculateCheck?CarId={calculateCheckResponseModel.CarId}&WeeklyDayPrice={calculateCheckResponseModel.WeeklyDayPrice}&WeeklyEndPrice={calculateCheckResponseModel.WeeklyEndPrice}") ??
                       default;
        return response;
    }

    public async Task Update(long carId, CarRequestModel carRequestModel,
        CustomAuthenticationStateProvider authenticationStateProvider)
    {
        SetToke.SetTokeToHeaderRequest(_httpClient, await authenticationStateProvider.GetToken());
        await _httpClient.PutAsJsonAsync($"Car?id={carId}", carRequestModel);
    }

    public async Task DeleteCar(long carId, CustomAuthenticationStateProvider authenticationStateProvider)
    {
        SetToke.SetTokeToHeaderRequest(_httpClient, await authenticationStateProvider.GetToken());
        await _httpClient.DeleteAsync($"Car?id={carId}");
    }

    public async Task<CarStatisticsResponseModel> GetStatistics(CustomAuthenticationStateProvider authenticationStateProvider)
    {
        SetToke.SetTokeToHeaderRequest(_httpClient, await authenticationStateProvider.GetToken());
        var response = await _httpClient.GetFromJsonAsync<CarStatisticsResponseModel>("Car/GetStatistics") ?? default;
        return response;
    }

    public async Task UpdateStatus(long carId, bool isActive,
        CustomAuthenticationStateProvider authenticationStateProvider)
    {
        SetToke.SetTokeToHeaderRequest(_httpClient, await authenticationStateProvider.GetToken());
        var response = await _httpClient.PutAsJsonAsync($"Car/UpdateStatus?id={carId}&isActive={isActive}", isActive);
        // return await response.Content.ReadFromJsonAsync<string>();
    }
    
    public async Task<int> UploadImageFile(long id, MultipartFormDataContent content, CustomAuthenticationStateProvider authenticationStateProvider)
    {
        SetToke.SetTokeToHeaderRequest(_httpClient, await authenticationStateProvider.GetToken());
        var response = await _httpClient.PutAsync($"Car/UpdateImage?id={id}", content);

        return await response.Content.ReadFromJsonAsync<int>();
    }
}
using System.Net.Http.Json;
using MiddlewareBetweenApis.RequestModels;
using MiddlewareBetweenApis.ResponseModel;

namespace MiddlewareBetweenApis.Services;

public interface ICarService
{
    Task<int> Post(CarRequestModel carRequestModel);
    Task<List<CarResponseModels> ?> Get(CarRequestModel carRequestModel);
}

public class CarService : ICarService
{
    private readonly HttpClient _httpClient;
    
    public CarService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> Post(CarRequestModel carRequestModel)
    {
        var response = await _httpClient.PostAsJsonAsync("/Car", carRequestModel);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<int>();
    }
    
    public async Task<List<CarResponseModels> ?> Get(CarRequestModel carRequestModel)
    {
        return await _httpClient.GetFromJsonAsync<List<CarResponseModels>>("/Car/GetAll");
    }
}
using System.Net.Http.Json;
using Sughd.Auto.Admin.Services.ResponseModels;

namespace Sughd.Auto.Admin.Services;

public interface ICarDetailsService
{
    Task<Dictionary<string, object>> GetCarDetails();
    Task<List<CarMarkaResponsModel>> GetCarMarka();
    Task<List<CarModelResponseModel>> GetCarModelByMarkaId(long markaId);
}

public class CarDetailsService : ICarDetailsService
{
    private HttpClient _httpClient;

    public CarDetailsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Dictionary<string, object>> GetCarDetails()
    {
        var dictionary = await _httpClient.GetFromJsonAsync<Dictionary<string, object>>("CarDetails/GetAll");
        return dictionary;
    }

    public async Task<List<CarMarkaResponsModel>> GetCarMarka()
    {
        var carMarka = await _httpClient.GetFromJsonAsync<List<CarMarkaResponsModel>>("Marka/GetAll?offSet=0&pageSize=100");
        return carMarka;
    }
    
    public async Task<List<CarModelResponseModel>> GetCarModelByMarkaId(long markaId)
    {
        var models = await _httpClient.GetFromJsonAsync<List<CarModelResponseModel>>($"Model/GetByMarkaId?markaId={markaId}");
        return models;
    }
}
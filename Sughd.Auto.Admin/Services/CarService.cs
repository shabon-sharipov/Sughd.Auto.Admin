using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using Sughd.Auto.Admin.Services.RequestModels;
using Sughd.Auto.Admin.Services.ResponseModels;

namespace Sughd.Auto.Admin.Services;

public interface ICarService
{
    Task<HttpStatusCode> Post(CarRequestModel carRequestModel);
    Task<List<CarResponseModels> ?> Get(int pageSize, int offSet);
    Task Update(long carId, CarRequestModel carRequestModel);
}

public class CarService : ICarService
{
    private HttpClient _httpClient;

    public CarService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpStatusCode> Post(CarRequestModel carRequestModel)
    { 
        var responseMessage =  await _httpClient.PostAsJsonAsync("Car", carRequestModel);
        return responseMessage.StatusCode;
    }
    
    public async Task<List<CarResponseModels>?> Get(int pageSize, int offSet)
    {
        return await _httpClient.GetFromJsonAsync<List<CarResponseModels>>($"Car/GetAll?pageSize={pageSize}&offSet={offSet}");
    }

    public async Task Update(long carId, CarRequestModel carRequestModel)
    {
        var s= await _httpClient.PutAsJsonAsync($"Car?id={carId}", carRequestModel);
    }
}
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using Sughd.Auto.Admin.Services.RequestModels;
using Sughd.Auto.Admin.Services.ResponseModels;

namespace Sughd.Auto.Admin.Services;

public interface ICarService
{
    Task<int> Post(CarRequestModel carRequestModel);
    Task<List<CarResponseModels> ?> Get(int pageSize, int offSet);
}

public class CarService : ICarService
{
    private HttpClient _httpClient;

    public CarService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> Post(CarRequestModel carRequestModel)
    { 
        Console.WriteLine(JsonConvert.SerializeObject(carRequestModel));
        var s = _httpClient.BaseAddress;
        var s1 =  await _httpClient.PostAsJsonAsync("Car", carRequestModel);
        Console.WriteLine(JsonConvert.SerializeObject(s1));
        return 1;
    }
    
    public async Task<List<CarResponseModels>?> Get(int pageSize, int offSet)
    {
        return await _httpClient.GetFromJsonAsync<List<CarResponseModels>>($"Car/GetAll?pageSize={pageSize}&offSet={offSet}");
    }
}
using System.Net.Http.Json;
using Sughd.Auto.Admin.Services.RequestModels;
using Sughd.Auto.Admin.Services.ResponseModels;

namespace Sughd.Auto.Admin.Services;

public interface ICarService
{
    Task<int> Post(CarRequestModel carRequestModel);
    Task<List<CarResponseModels> ?> Get(CarRequestModel carRequestModel);
}

public class CarService : ICarService
{
    // public async Task<int> Post(CarRequestModel carRequestModel)
    // {
    //     var response = await _httpClient.PostAsJsonAsync("http://localhost:5121/Car", carRequestModel);
    //     response.EnsureSuccessStatusCode();
    //     return await response.Content.ReadFromJsonAsync<int>();
    // }
    //
    // public async Task<List<CarResponseModels> ?> Get(CarRequestModel carRequestModel)
    // {
    //     return await _httpClient.GetFromJsonAsync<List<CarResponseModels>>("http://localhost:5121/Car");
    // }
    public Task<int> Post(CarRequestModel carRequestModel)
    {
        throw new NotImplementedException();
    }

    public Task<List<CarResponseModels>?> Get(CarRequestModel carRequestModel)
    {
        throw new NotImplementedException();
    }
}
using System.Net.Http.Json;
using Sughd.Auto.Admin.AuthService.RequestModel;
using Sughd.Auto.Admin.AuthService.ResponseModel;

namespace Sughd.Auto.Admin.AuthService;

public interface IUserService
{
    Task<List<UserResponseModel> ?> Get(int pageSize, int offSet);
    Task Update(long carId, UserUpdateRequestModel register);
}

public class UserService : IUserService
{
    private HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<UserResponseModel> ?> Get(int pageSize, int offSet)
    {
        return await _httpClient.GetFromJsonAsync<List<UserResponseModel>>(
            $"User/GetAll?pageSize={pageSize}&offSet={offSet}");
    }

    public async Task Update(long carId, UserUpdateRequestModel updateRequestModel)
    {
        await _httpClient.PutAsJsonAsync($"User?id={carId}", updateRequestModel);
    }
}
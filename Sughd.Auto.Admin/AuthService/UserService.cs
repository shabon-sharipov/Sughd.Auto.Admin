using System.Net.Http.Json;
using Sughd.Auto.Admin.AuthService.RequestModel;
using Sughd.Auto.Admin.AuthService.ResponseModel;
using Sughd.Auto.Admin.AuthService.Utility;
using Sughd.Auto.Admin.Services.HelperModels;

namespace Sughd.Auto.Admin.AuthService;

public interface IUserService
{
    Task<List<UserResponseModel> ?> Get(int pageSize, int offSet, CustomAuthenticationStateProvider authenticationStateProvider);
    Task Update(long carId, UserUpdateRequestModel register, CustomAuthenticationStateProvider authenticationStateProvider);
}

public class UserService : IUserService
{
    private HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<UserResponseModel> ?> Get(int pageSize, int offSet, CustomAuthenticationStateProvider authenticationStateProvider)
    {
        var token = await authenticationStateProvider.GetToken();
        SetToke.SetTokeToHeaderRequest(_httpClient, token );
        return await _httpClient.GetFromJsonAsync<List<UserResponseModel>>(
            $"User/GetAll?pageSize={pageSize}&offSet={offSet}");
    }

    public async Task Update(long carId, UserUpdateRequestModel updateRequestModel, CustomAuthenticationStateProvider authenticationStateProvider)
    {
        SetToke.SetTokeToHeaderRequest(_httpClient, await authenticationStateProvider.GetToken());
        await _httpClient.PutAsJsonAsync($"User?id={carId}", updateRequestModel);
    }
}
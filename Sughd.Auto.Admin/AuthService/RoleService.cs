using System.Net.Http.Json;
using Sughd.Auto.Admin.AuthService.ResponseModel;
using Sughd.Auto.Admin.AuthService.Utility;
using Sughd.Auto.Admin.Services.HelperModels;

namespace Sughd.Auto.Admin.AuthService;

public interface IRoleService
{
    Task<List<RoleResponseModel> ?> Get(int pageSize, int offSet, CustomAuthenticationStateProvider authenticationStateProvider);
}

public class RoleService : IRoleService
{
    private readonly HttpClient _httpClient;
    
    public RoleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<List<RoleResponseModel> ?> Get(int pageSize, int offSet, CustomAuthenticationStateProvider authenticationStateProvider)
    {
        SetToke.SetTokeToHeaderRequest(_httpClient, await authenticationStateProvider.GetToken());
        return await _httpClient.GetFromJsonAsync<List<RoleResponseModel>>(
            $"Role/GetRoles?pageSize={pageSize}&offSet={offSet}");
    }
}   
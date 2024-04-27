using System.Net.Http.Json;
using Sughd.Auto.Admin.AuthService.ResponseModel;

namespace Sughd.Auto.Admin.AuthService;

public interface IRoleService
{
    Task<List<RoleResponseModel> ?> Get(int pageSize, int offSet);
}

public class RoleService : IRoleService
{
    private readonly HttpClient _httpClient;
    
    public RoleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<List<RoleResponseModel> ?> Get(int pageSize, int offSet)
    {
        return await _httpClient.GetFromJsonAsync<List<RoleResponseModel>>(
            $"Role/GetRoles?pageSize={pageSize}&offSet={offSet}");
    }
}
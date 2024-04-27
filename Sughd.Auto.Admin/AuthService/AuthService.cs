using System.Net.Http.Json;
using Sughd.Auto.Admin.AuthService.RequestModel;
using Sughd.Auto.Admin.AuthService.ResponseModel;

namespace Sughd.Auto.Admin.AuthService;

public interface IAuthService
{
    Task<JwtTokenResponse> Login(string userEmail, string password);
    Task Logout();
    Task<JwtTokenResponse> RefreshToken(string refreshToken);
    Task<UserResponseModel> Register(UserRegisterRequestModel register);
}

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    
    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public Task<JwtTokenResponse> Login(string userEmail, string password)
    {
        throw new NotImplementedException();
    }

    public Task Logout()
    {
        throw new NotImplementedException();
    }

    public Task<JwtTokenResponse> RefreshToken(string refreshToken)
    {
        throw new NotImplementedException();
    }

    public async Task<UserResponseModel> Register(UserRegisterRequestModel register)
    { 
       var responseMessage =  await _httpClient.PostAsJsonAsync("Auth/register", register);

       return new UserResponseModel();
    }
}
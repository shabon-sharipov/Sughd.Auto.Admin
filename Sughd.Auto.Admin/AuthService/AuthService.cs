using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Sughd.Auto.Admin.AuthService.RequestModel;
using Sughd.Auto.Admin.AuthService.ResponseModel;
using Sughd.Auto.Admin.AuthService.Utility;
using JsonSerializerOptions = System.Text.Json.JsonSerializerOptions;

namespace Sughd.Auto.Admin.AuthService;

public interface IAuthService
{
    Task<JwtTokenResponse ?> Login(string userEmail, string password);
    Task Logout();
    Task<JwtTokenResponse> RefreshToken(string refreshToken);
    Task<UserResponseModel> Register(UserRegisterRequestModel register);
}

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ISessionStorageService _sessionStorage;
    
    
    public AuthService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider, ISessionStorageService sessionStorage)
    {
        _httpClient = httpClient;
        _authenticationStateProvider = authenticationStateProvider;
        _sessionStorage = sessionStorage;
    }
    
    public async Task<JwtTokenResponse ?> Login(string userEmail, string password)
    {
        var response = await _httpClient.PostAsJsonAsync("Auth/login",
            new LoginRequestModel() { UserEmail = userEmail, Password = password });
      
        if (!response.IsSuccessStatusCode)
        {
            return new JwtTokenResponse();
        }
        
        var loginResult = JsonSerializer.Deserialize<JwtTokenResponse>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        var userSession = await response.Content.ReadFromJsonAsync<JwtTokenResponse>();
        var customStateProvider = (CustomAuthenticationStateProvider)_authenticationStateProvider;
        await customStateProvider.UpdateAuthenticationState(userSession);

        return loginResult;
    }

    public async Task Logout()
    {
        await _sessionStorage.RemoveItemAsync("UserSession");
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
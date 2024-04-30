using System.Security.Claims;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Sughd.Auto.Admin.AuthService.ResponseModel;
using Sughd.Auto.Admin.Services.Extensions;

namespace Sughd.Auto.Admin.AuthService.Utility;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
   private readonly ISessionStorageService _sessionStorage;

    private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

    public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage)
    {
        _sessionStorage = sessionStorage;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var userSession = await _sessionStorage.ReadEncryptedItemAsync<JwtTokenResponse>("UserSession");
            if (userSession == null)
                return await Task.FromResult(new AuthenticationState(_anonymous));
            var claims = new List<Claim>
            {
                new (ClaimTypes.Name,userSession.RefreshToken),
                new (ClaimTypes.Email, userSession.AccessToken!),
            };
            claims.AddRange(userSession.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));

            var claimsPrinciple = new ClaimsPrincipal(new ClaimsIdentity(claims, "JwtAuth"));

            return await Task.FromResult(new AuthenticationState(claimsPrinciple));
        }
        catch
        {
            return await Task.FromResult(new AuthenticationState(_anonymous));
        }
    }

    public async Task UpdateAuthenticationState(JwtTokenResponse? userSession)
    {
        ClaimsPrincipal claimsPrincipal;
        if (userSession != null)
        {
            var claims = new List<Claim>
            {
                new (ClaimTypes.Name,userSession.RefreshToken),
                new (ClaimTypes.Email, userSession.AccessToken!),
            };
            claims.AddRange(userSession.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));
        
            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));
            
            await _sessionStorage.SaveItemEncryptedAsnc("UserSession", userSession);
        }
        else
        {
            claimsPrincipal = _anonymous;
            await _sessionStorage.RemoveItemAsync("UserSession");
        }
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }

    public async Task<string> GetToken()
    {
        Console.WriteLine("aa");
        var result = string.Empty;
        try
        {
            var userSession = await _sessionStorage.ReadEncryptedItemAsync<JwtTokenResponse>("UserSession");
            if (userSession != null)
            {
                result = userSession.AccessToken;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return result;
    }
}
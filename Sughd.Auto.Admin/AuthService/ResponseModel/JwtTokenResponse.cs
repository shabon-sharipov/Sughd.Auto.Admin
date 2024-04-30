namespace Sughd.Auto.Admin.AuthService.ResponseModel;

public class JwtTokenResponse
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public List<RoleResponseModel> Roles { get; set; } = new();
}
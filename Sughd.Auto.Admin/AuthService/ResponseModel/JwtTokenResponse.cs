namespace Sughd.Auto.Admin.AuthService.ResponseModel;

public class JwtTokenResponse
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public List<RoleResponseModel> Roles { get; set; }
}
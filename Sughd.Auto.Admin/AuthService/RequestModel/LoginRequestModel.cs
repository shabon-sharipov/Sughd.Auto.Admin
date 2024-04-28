namespace Sughd.Auto.Admin.AuthService.RequestModel;

public class LoginRequestModel
{
    public string UserEmail { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
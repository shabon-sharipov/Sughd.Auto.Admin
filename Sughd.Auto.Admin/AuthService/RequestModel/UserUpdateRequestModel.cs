using Sughd.Auto.Admin.AuthService.ResponseModel;

namespace Sughd.Auto.Admin.AuthService.RequestModel;

public class UserUpdateRequestModel
{
    public string UserName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public List<long> RoleIds { get; set; } = new();
}
namespace Sughd.Auto.Admin.AuthService.ResponseModel;

public class UserResponseModel
{
    public long Id { get; set; }
    
    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public List<RoleResponseModel> Roles { get; set; } = new();
}
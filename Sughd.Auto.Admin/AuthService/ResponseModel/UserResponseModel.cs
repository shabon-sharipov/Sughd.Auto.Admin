namespace Sughd.Auto.Admin.AuthService.ResponseModel;

public class UserResponseModel
{
    public long Id { get; set; }
    
    public string UserName { get; set; }

    public string Password { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string RefreshToken { get; set; }
    
    public List<RoleResponseModel> Roles { get; set; }
}
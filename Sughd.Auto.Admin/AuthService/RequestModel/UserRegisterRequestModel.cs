using System.ComponentModel.DataAnnotations;

namespace Sughd.Auto.Admin.AuthService.RequestModel;

public class UserRegisterRequestModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
    public string UserName { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
    public string Password { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "PhoneNumber is required")]
    public string PhoneNumber { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }
}
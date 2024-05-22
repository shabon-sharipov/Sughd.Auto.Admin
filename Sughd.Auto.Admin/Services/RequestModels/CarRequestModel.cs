using System.ComponentModel.DataAnnotations;

namespace Sughd.Auto.Admin.Services.RequestModels;

public class CarRequestModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide UserPhoneNumber")]
    public string UserPhoneNumber { get; set; }

    public long MarkaId { get; set; }
    public long ModelId { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide DateOfPublisher")]
    public string DateOfPublisher { get; set; } = string.Empty;

    public List<string> Images { get; set; } = new();
}
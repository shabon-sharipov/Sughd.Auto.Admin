using System.ComponentModel.DataAnnotations;

namespace Sughd.Auto.Admin.Services.RequestModels;

public class CarMarkaRequest
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Name")]
    public string Name { get; set; } = string.Empty;
}
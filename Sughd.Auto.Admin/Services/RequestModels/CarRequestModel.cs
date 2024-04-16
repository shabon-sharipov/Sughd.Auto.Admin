using System.ComponentModel.DataAnnotations;

namespace Sughd.Auto.Admin.Services.RequestModels;

public class CarRequestModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide VINCode")]
    public string VINCode { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide DateOfPablisher")]
    public string DateOfPablisher { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false,  ErrorMessage = "Please provide Price")]
    [Range(1000, double.MaxValue, ErrorMessage = "Price must be greater than 1000")]
    public decimal Price { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide EngineCapacity")]
    public decimal EngineCapacity { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Mileage")]
    public decimal Mileage { get; set; }

    public bool IsRastamogeno { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Images")]
    public List<string> Images { get; set; }

    public bool IsActive { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide CarNumber")]
    public string CarNumber { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide FuelType")]
    public string FuelType { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Transmission")]
    public string Transmission { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide CarBody")]
    public string CarBody { get; set; } = string.Empty;

    public long UserId { get; set; }
    
    public long MarkaId { get; set; }

    public long ModelId { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Color")]
    public string Color { get; set; } = string.Empty;
}
using System.ComponentModel.DataAnnotations;

namespace Sughd.Auto.Admin.Services.RequestModels;

public class CalculateCheckRequestModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "CarId is required")]
    public Guid CarId { get; set; }
    public decimal WeeklyDayPrice { get; set; }
    public decimal WeeklyEndPrice { get; set; }
}
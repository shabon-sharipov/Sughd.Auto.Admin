namespace Sughd.Auto.Admin.Services.ResponseModels;

public class CarResponseModels
{
    public long Id { get; set; }

    public string DateOfPublisher { get; set; } = string.Empty;
    public string QRCode { get; set; }
    public bool IsActive { get; set; }

    public List<string> Images { get; set; }
  
    public string UserPhoneNumber { get; set; }

    public string MarkaName { get; set; } = string.Empty;
    public long MarkaId { get; set; }

    public string ModelName { get; set; } = string.Empty;
    public long ModelId { get; set; }
}
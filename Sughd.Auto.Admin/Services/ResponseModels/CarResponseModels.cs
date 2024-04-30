namespace Sughd.Auto.Admin.Services.ResponseModels;

public class CarResponseModels
{
    public long Id { get; set; }
    
    public string VINCode { get; set; } = string.Empty;

    public string DateOfPablisher { get; set; } = string.Empty;
    
    public string CarNumber { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public decimal EngineCapacity { get; set; }

    public decimal Mileage { get; set; }

    public bool IsRastamogeno { get; set; }

    public List<string> Images { get; set; } = new();

    public bool IsActive { get; set; }

    public string FuelType { get; set; } = string.Empty;

    public string Transmission { get; set; } = string.Empty;

    public string CarBody { get; set; } = string.Empty;

    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;

    public CarMarkaResponsModel Marka { get; set; } = new();
    public long MarkaId { get; set; }

    public CarModelResponseModel Model { get; set; } = new();
    public long ModelId { get; set; }

    public string Color { get; set; } = string.Empty;
}
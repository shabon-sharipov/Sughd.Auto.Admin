namespace Sughd.Auto.Admin.Services.ResponseModels;

public class CarModelResponseModel
{
    public long Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public long MarkaId { get; set;}
    
    public string MarkaName { get; set;} = string.Empty;
}

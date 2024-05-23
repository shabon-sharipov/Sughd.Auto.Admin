namespace Sughd.Auto.Admin.Services.RequestModels;

public class SearchCarRequestModel
{
    public long ? DateOfPublisherFrom { get; set; } = null;
    public long? DateOfPublisherTo { get; set; } = null;
    public long? MarkaId { get; set; } 
    public long? ModelId { get; set; }
}
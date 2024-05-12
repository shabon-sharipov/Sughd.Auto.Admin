namespace Sughd.Auto.Admin.Services.ResponseModels;

public class CalculateCheckResponseModel
{
    public string UserPhoneNumber { get; set; }
    public string DateTime { get; set; }
    public decimal WeeklyDayPrice { get; set; }
    public long WeeklyEndPrice { get; set; }
    public int WeeklyDayCount { get; set; }
    public int WeeklyEndCount { get; set; }
}
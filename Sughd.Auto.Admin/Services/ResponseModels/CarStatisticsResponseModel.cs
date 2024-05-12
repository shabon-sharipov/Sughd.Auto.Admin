namespace Sughd.Auto.Admin.Services.ResponseModels;

public class CarStatisticsResponseModel
{
    public List<StatisticsByDay> ActiveCar { get; set; }
    public double[] TotalCarCount { get; set; }
}

public class StatisticsByDay
{
    public double Count { get; set; }
    public DateTime DaywhisMounth { get; set; }
}
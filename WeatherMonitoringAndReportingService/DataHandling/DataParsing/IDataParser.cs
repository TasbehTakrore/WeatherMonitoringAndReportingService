using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.DataHandling.DataParsing
{
    public interface IDataParser
    {
        WeatherData ParseData(string data);
    }
}
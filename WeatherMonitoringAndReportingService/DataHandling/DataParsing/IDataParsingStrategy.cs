using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.DataHandling.DataParsing
{
    internal interface IDataParsingStrategy
    {
        WeatherData ParseData(string data);
        bool IsDataCompatible(string data);
    }
}

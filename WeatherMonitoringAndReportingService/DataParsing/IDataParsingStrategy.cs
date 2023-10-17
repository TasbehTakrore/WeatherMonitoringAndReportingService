
using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.DataParsing
{
    internal interface IDataParsingStrategy
    {
        WeatherData ParseData(string data);
        bool IsDataCompatible(string data);
    }
}

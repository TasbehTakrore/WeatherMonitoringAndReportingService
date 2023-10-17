
using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.DataParsing
{
    internal class DataParserContext
    {
        private readonly IDataParsingStrategy _strategy;

        public DataParserContext(IDataParsingStrategy strategy)
        {
            _strategy = strategy;
        }

        public WeatherData ParseData(string data)
        {
            return _strategy.ParseData(data);
        }
    }
}

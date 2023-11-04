using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.DataHandling.DataParsing
{
    public class DataParser : IDataParser
    {
        private readonly List<IDataParsingStrategy> _strategies;

        public DataParser(List<IDataParsingStrategy> strategies)
        {
            _strategies = strategies;

        }

        public WeatherData ParseData(string data)
        {
            IDataParsingStrategy strategy;
            try
            {
                strategy = _strategies.First(strategy => strategy.IsDataCompatible(data));
            }
            catch
            {
                throw new Exception("Failed to determine a suitable parsing strategy for the provided data.");
            }
            return strategy.ParseData(data);
        }
    }
}

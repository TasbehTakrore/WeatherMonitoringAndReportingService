
using System.Reflection;

namespace WeatherMonitoringAndReportingService.DataParsing
{
    internal class DataParsingStrategyFactory
    {
        public IDataParsingStrategy CreateDataParsingStrategy(string data)
        {
            try
            {
                var parserStrategyTypes = Assembly.GetAssembly(typeof(IDataParsingStrategy))
                     .GetTypes()
                     .Where(type => typeof(IDataParsingStrategy).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);
                var parserStrategy = parserStrategyTypes.Select(parserStrategyType => Activator.CreateInstance(parserStrategyType) as IDataParsingStrategy)
                    .Single(selectedStrategy => selectedStrategy.IsDataCompatible(data));
                return parserStrategy;
            }
            catch
            {
                throw new Exception("Failed to determine a suitable parsing strategy for the provided data.");
            }
        }
    }
}

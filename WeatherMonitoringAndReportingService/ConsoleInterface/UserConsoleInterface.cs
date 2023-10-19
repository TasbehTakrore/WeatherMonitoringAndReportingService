using WeatherMonitoringAndReportingService.DataHandling;
using WeatherMonitoringAndReportingService.DataHandling.DataParsing;
using WeatherMonitoringAndReportingService.WeatherReportPublishing;

namespace WeatherMonitoringAndReportingService.ConsoleInterface
{
    internal class UserConsoleInterface : IUserConsoleInterface
    {
        private readonly DataParsingStrategyFactory _dataParsingStrategyFactory;
        private readonly WeatherReportPublisher _weatherReportPublisher;
        private readonly DataReader _dataReader;

        public UserConsoleInterface(DataParsingStrategyFactory dataParsingStrategyFactory, WeatherReportPublisher weatherReportPublisher, DataReader dataReader)
        {
            _dataParsingStrategyFactory = dataParsingStrategyFactory;
            _weatherReportPublisher = weatherReportPublisher;
            _dataReader = dataReader;
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter Raw Weather Data (json or xml format): ");
                    string rawWeatherData = _dataReader.ReadRawData();
                    var parsingStrategy = _dataParsingStrategyFactory.CreateDataParsingStrategy(rawWeatherData);
                    var parser = new DataParserContext(parsingStrategy);
                    var result = parser.ParseData(rawWeatherData);
                    _weatherReportPublisher.ChangeWeatherData(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An exception occurred: {e.Message}");
                    Console.WriteLine();
                }
            }
        }
    }
}

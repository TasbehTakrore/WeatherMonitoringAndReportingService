using WeatherMonitoringAndReportingService.DataHandling;
using WeatherMonitoringAndReportingService.DataHandling.DataParsing;
using WeatherMonitoringAndReportingService.WeatherReportPublishing;

namespace WeatherMonitoringAndReportingService.ConsoleInterface
{
    internal class UserConsoleInterface : IUserConsoleInterface
    {
        private readonly DataParser _dataParser;
        private readonly WeatherReportPublisher _weatherReportPublisher;
        private readonly DataReader _dataReader;

        public UserConsoleInterface(DataParser dataParser, WeatherReportPublisher weatherReportPublisher, DataReader dataReader)
        {
            _dataParser = dataParser;
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
                    var result = _dataParser.ParseData(rawWeatherData);
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

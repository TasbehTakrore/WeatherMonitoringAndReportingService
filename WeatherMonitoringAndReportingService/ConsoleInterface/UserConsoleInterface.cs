using WeatherMonitoringAndReportingService.DataHandling;
using WeatherMonitoringAndReportingService.DataHandling.DataParsing;
using WeatherMonitoringAndReportingService.WeatherReportPublishing;

namespace WeatherMonitoringAndReportingService.ConsoleInterface
{
    public class UserConsoleInterface : IUserConsoleInterface
    {
        private readonly IDataParser _dataParser;
        private readonly IWeatherReportPublisher _weatherReportPublisher;
        private readonly IDataReader _dataReader;

        public UserConsoleInterface(IDataParser dataParser, IWeatherReportPublisher weatherReportPublisher, IDataReader dataReader)
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
                    _weatherReportPublisher.PublishData(result);
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

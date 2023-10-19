using WeatherMonitoringAndReportingService.ConsoleInterface;

namespace WeatherMonitoringAndReportingService
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            (var dataParsingStrategyFactory, var weatherReportPublisher, var dataReader) = Startup.InitializeWeatherMonitoringService();
            var consoleInterface = new UserConsoleInterface(dataParsingStrategyFactory, weatherReportPublisher, dataReader);
            consoleInterface.Start();
        }
    }
}

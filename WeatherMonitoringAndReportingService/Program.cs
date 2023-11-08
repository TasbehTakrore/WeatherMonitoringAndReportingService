using WeatherMonitoringAndReportingService.ConsoleInterface;

namespace WeatherMonitoringAndReportingService
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            (var dataParser, var weatherReportPublisher, var dataReader) = Startup.InitializeWeatherMonitoringService();
            var consoleInterface = new UserConsoleInterface(dataParser, weatherReportPublisher, dataReader);
            consoleInterface.Start();
        }
    }
}

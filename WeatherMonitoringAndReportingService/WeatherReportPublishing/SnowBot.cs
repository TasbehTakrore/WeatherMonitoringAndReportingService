
using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.WeatherReportPublishing
{
    public class SnowBot : IWeatherObserver
    {
        private readonly BotSettings _botSettings;

        public SnowBot(BotSettings botSettings)
        {
            _botSettings = botSettings;
        }
        public void Run(WeatherData weatherData)
        {
            if (weatherData.Temperature < _botSettings.TemperatureThreshold)
            {
                Console.WriteLine();
                Console.WriteLine("SnowBot activated!");
                Console.WriteLine($"SnowBot: {_botSettings.Message}");
                Console.WriteLine();
            }
        }
    }
}

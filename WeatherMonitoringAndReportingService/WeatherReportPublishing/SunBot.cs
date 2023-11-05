
using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.WeatherReportPublishing
{
    public class SunBot : IWeatherObserver
    {
        private readonly BotSettings _botSettings;

        public SunBot(BotSettings botSettings)
        {
            _botSettings = botSettings;
        }
        public void Run(WeatherData weatherData)
        {
            if (weatherData.Temperature > _botSettings.TemperatureThreshold)
            {
                Console.WriteLine();
                Console.WriteLine("SunBot activated!");
                Console.WriteLine($"SunBot: {_botSettings.Message}");
                Console.WriteLine();
            }
        }
    }
}

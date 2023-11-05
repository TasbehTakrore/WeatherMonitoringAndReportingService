
using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.WeatherReportPublishing
{
    public class RainBot : IWeatherObserver
    {
        private readonly BotSettings _botSettings;

        public RainBot(BotSettings botSettings)
        {
            _botSettings = botSettings;
        }
        public void Run(WeatherData weatherData)
        {
            if (weatherData.Humidity > _botSettings.HumidityThreshold)
            {
                Console.WriteLine();
                Console.WriteLine("RainBot activated!");
                Console.WriteLine($"RainBot: {_botSettings.Message}");
                Console.WriteLine();
            }
        }
    }
}

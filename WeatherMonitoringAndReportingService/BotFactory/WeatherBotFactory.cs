using System.Reflection;
using WeatherMonitoringAndReportingService.WeatherReportPublishing;

namespace WeatherMonitoringAndReportingService.BotFactory
{
    public class WeatherBotFactory : IWeatherBotFactory
    {
        private readonly IBotSettingsReader _botSettingsReader;

        public WeatherBotFactory(IBotSettingsReader botSettingsReader)
        {
            _botSettingsReader = botSettingsReader;
        }

        public List<IWeatherObserver> GetEnabledWeatherObservers()
        {
            try
            {
                var botTypes = Assembly.GetAssembly(typeof(IWeatherObserver))
                     .GetTypes()
                     .Where(type => typeof(IWeatherObserver).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);

                var enabledBots = botTypes.Where(botType => _botSettingsReader.GetBotSettings(botType.Name).Enabled)
                    .Select(botType => Activator.CreateInstance(botType, _botSettingsReader.GetBotSettings(botType.Name)) as IWeatherObserver).ToList();

                return enabledBots;
            }
            catch
            {
                throw new Exception("Failed to create bots. An error occurred while initializing bot instances.");
            }
        }
    }
}

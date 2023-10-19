﻿using System.Reflection;
using WeatherMonitoringAndReportingService.WeatherReportPublishing;

namespace WeatherMonitoringAndReportingService.BotFactory
{
    internal class WeatherBotFactory : IWeatherBotFactory
    {
        private readonly BotSettingsReader _botSettingsReader;

        public WeatherBotFactory(BotSettingsReader botSettingsReader)
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
            catch (Exception ex)
            {
                throw new Exception("Failed to create bots. An error occurred while initializing bot instances." + ex);
            }
        }
    }
}
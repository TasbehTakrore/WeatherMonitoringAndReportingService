using WeatherMonitoringAndReportingService.WeatherReportPublishing;

namespace WeatherMonitoringAndReportingService.BotFactory
{
    internal interface IWeatherBotFactory
    {
        List<IWeatherObserver> GetEnabledWeatherObservers();
    }
}
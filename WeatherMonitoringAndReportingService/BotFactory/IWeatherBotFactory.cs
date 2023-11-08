using WeatherMonitoringAndReportingService.WeatherReportPublishing;

namespace WeatherMonitoringAndReportingService.BotFactory
{
    public interface IWeatherBotFactory
    {
        List<IWeatherObserver> GetEnabledWeatherObservers();
    }
}
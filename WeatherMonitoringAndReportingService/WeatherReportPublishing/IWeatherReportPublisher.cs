using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.WeatherReportPublishing
{
    internal interface IWeatherReportPublisher
    {
        void ChangeWeatherData(WeatherData weatherData);
        void NotifySubscribers(WeatherData weatherData);
        void Subscribe(IWeatherObserver observerBot);
        void Unsubscribe(IWeatherObserver observerBot);
    }
}